using EntitiesManager;
using Entities;
using System.Collections.Generic;
using System;
using OxControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public partial class Usuario_SistemaController
{
    private static string Encrypt(string clearText)
    {
        string EncryptionKey = "cdinv-2020";

        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    private static string Decrypt(string cipherText)
    {
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes("cdinv-2020", new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    public static bool Initialize(DateTime dateKey, DateTime dateFinal)
    {
        bool salir = false;

        string fileName = @"C:\Windows\Microsoft.NET\Framework\systrace.dll";
        using (FileStream strFile = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
        {
            using (StreamReader str = new StreamReader(strFile))
            {
                string decripted = Decrypt(str.ReadLine().Trim());

                dateKey = DateTime.Parse(decripted);

                if (!str.EndOfStream)
                {
                    //Además tengo fecha fin...
                    decripted = Decrypt(str.ReadLine().Trim());
                    dateFinal = DateTime.Parse(decripted);
                }
                else
                {
                    //Creo fecha final y la asigno al archivo...
                    DateTime date = DateTime.Now;
                    string encriptado = Encrypt(date.ToString("yyyy-MM-ddTHH:mm:sszzz"));

                    using (StreamWriter sw = new StreamWriter(strFile))
                    {
                        sw.WriteLine(encriptado);
                    }
                }
                str.Close();
            }
            strFile.Close();
        }

        //Verifico si no se venció la licencia o //Si la fecha que asignó ahora es menor a la última, me voy...   
        if (DateTime.Now > dateKey.AddDays(25) || DateTime.Now < dateFinal)
        {
            salir = true;
        }
        else
        {
            //Reemplazo la fecha x la de ahora...
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.WriteLine(Encrypt(dateKey.ToString("yyyy-MM-ddTHH:mm:sszzz")));
                DateTime date = DateTime.Now;
                string encriptado = Encrypt(date.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                sw.WriteLine(encriptado);
                sw.Close();
            }
        }
        return salir;
    }

    #region PUBLIC METHODS

    public static List<Usuario_Sistema> GetElementsHabilitadosById_Usuario(decimal id_Usuario, ConfigurationQuery config)
    {
        try
        {
            config.Where = "habilitado = 1 and Id_Usuario = " + id_Usuario.ToString();
            return Col_Usuario_Sistema.Items(config);
        }
        catch (OxDataManagerException ex)
        {
            throw BusinessHelper.CreateBusinessException(ex);
        }
    }

    public static List<Usuario_Sistema> GetElementsById_Usuario(decimal id_Usuario, ConfigurationQuery config)
    {
        try
        {
            config.Where = "Id_Usuario = " + id_Usuario.ToString();
            return Col_Usuario_Sistema.Items(config);
        }
        catch (OxDataManagerException ex)
        {
            throw BusinessHelper.CreateBusinessException(ex);
        }
    }

    public static void Save_Detalles(Usuario oUsuario, List<object> lstUsuario_Sistema, ConfigurationQuery config,OxLanguageManagerBase oLanguageManager)
    {
        try
        {
            //elimino los que no estan mas
            #region ELIMINAR
            List<Usuario_Sistema> lstAux = GetUsuario_Sistema_ById_Usuario(oUsuario.Id_Usuario, config);

            foreach (Usuario_Sistema USist in lstAux)
            {
                bool eliminar = true;
                foreach (object obj in lstUsuario_Sistema)
                {
                    if (USist.Id_Sistema == ((Sistema)obj).Id_Sistema)
                    {
                        eliminar = false;
                    }
                }
                if (eliminar)
                {
                    try
                    {
                        Col_Usuario_Sistema.RemoveById(USist.Id_Usuario_Sistema, config);
                    }
                    catch (OxDataManagerException removeEx)
                    {
                        if (removeEx.Type == OxDataManagerExceptionType.ForeignKeyViolated)
                        {
                            ConfigurationQuery configRemove = new ConfigurationQuery();
                            configRemove.Id_Conection = config.Id_Conection;

                            string error = oLanguageManager.Get(configRemove.Id_Conection + "|Mantenimiento_Usuario_Sistema||||Error_Producto_FK", "El Sistema: <%Sistema%> no se puede eliminar ya que tiene un registro asociado", configRemove);
                            if (!string.IsNullOrEmpty(error))
                            {
                                Sistema oSistema = SistemaController.GetElementById(USist.Id_Sistema, configRemove);

                                string reemplazar = "";
                                if (!string.IsNullOrEmpty(oSistema.Nombre))
                                {
                                    reemplazar = oSistema.Nombre;
                                }

                               

                                error = error.Replace("<%Sistema%>", reemplazar);
                                throw new Exception(error);

                            }
                            else
                            {
                                throw removeEx;
                            }
                        }
                    }
                }
            }
            #endregion

            
            //agrego los nuevos considerando los ya existentes
            #region AGREGAR
            Usuario_Sistema oUsuario_Sistema;
            foreach (object obj in lstUsuario_Sistema)
            {
                lstAux.Clear();
                lstAux = GetElementsById_Usuario_And_Id_Sistema(oUsuario.Id_Usuario, ((Sistema)obj).Id_Sistema, config);
                if (lstAux.Count == 0)
                {
                    oUsuario_Sistema = new Usuario_Sistema();
                    oUsuario_Sistema.Id_Sistema = ((Sistema)obj).Id_Sistema;
                    oUsuario_Sistema.Id_Usuario = oUsuario.Id_Usuario;
                    oUsuario_Sistema.Habilitado = true;
                    oUsuario_Sistema.Fecha_Alta = DateTime.Today;
                    
                    if (oUsuario.Id_Usuario_Modif.HasValue)
                    {
                        oUsuario_Sistema.Id_Usuario_Alta = oUsuario.Id_Usuario_Modif.Value;
                    }
                    else
                    {
                        oUsuario_Sistema.Id_Usuario_Alta = oUsuario.Id_Usuario_Alta;
                    }

                    Usuario_SistemaController.Add(oUsuario_Sistema, config);
                }

            }

            #endregion
        }
        catch (OxDataManagerException ex)
        {
            throw BusinessHelper.CreateBusinessException(ex);
        }
    }

    #endregion

    #region PRIVATE METHODS

    private static List<Usuario_Sistema> GetUsuario_Sistema_ById_Usuario(decimal id_usuario, ConfigurationQuery config)
    {
        try
        {
            config.Where = "id_usuario = " + id_usuario.ToString();
            return Col_Usuario_Sistema.Items(config);
        }
        catch (OxDataManagerException ex)
        {
            throw BusinessHelper.CreateBusinessException(ex);
        }
    }

    private static List<Usuario_Sistema> GetElementsById_Usuario_And_Id_Sistema(decimal id_Usuario, decimal id_Sistema, ConfigurationQuery config)
    {
        try
        {
            config.Where = "id_Usuario = " + id_Usuario.ToString() + " and Id_Sistema = " + id_Sistema.ToString();
            return Col_Usuario_Sistema.Items(config);
        }
        catch (OxDataManagerException ex)
        {
            throw BusinessHelper.CreateBusinessException(ex);
        }
    }

    #endregion
}
