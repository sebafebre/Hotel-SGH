using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora
{
    public class ValidacionesBLL
    {
        ValidacionesDAL validacionesDAL = new ValidacionesDAL();
        //retornar las validaciones que se encuentran en ValidacionesDAL
        //AbrirFormulario
        public static void AbrirFormulario(Type tipoFormulario, Form frmMenu)
        {
            ValidacionesDAL.AbrirFormulario(tipoFormulario, frmMenu);
        }

        //CambiarPanel
        public static void CambiarPanel(Type tipoFormulario, Form frmMenu)
        {
            ValidacionesDAL.CambiarPanel(tipoFormulario, frmMenu);
        }

        public void LimpiarCampos(Control.ControlCollection controles)
        {
            validacionesDAL.LimpiarCampos(controles);
        }

        public void BuscarPorDNI(string dni, DataGridView dgvClientes)
        {
            validacionesDAL.BuscarPorDNI(dni, dgvClientes);
        }

        public string ObtenerEstadoSeleccionado(Control flowLayoutPanel)
        {
            return validacionesDAL.ObtenerEstadoSeleccionado(flowLayoutPanel);
        }







        public  void ValidarMail(string mail)
        {
            try
            {
                MailAddress m = new MailAddress(mail);
            }
            catch (FormatException)
            {
                throw new Exception("Formato de mail invalido");
            }
        }
        public  void ValidarDni(string dni)
        {
            if (dni.Length < 7 || dni.Length > 8)
            {
                throw new Exception("El DNI debe tener entre 7 y 8 caracteres");
            }
        }
        public void ValidarTelefono(string telefono)
        {
            if (telefono.Length < 7 || telefono.Length > 11)
            {
                throw new Exception("El telefono debe tener entre 7 y 11 caracteres");
            }
        }
        public  void ValidarFechaNac(DateTime fechaNac)
        {
            if (fechaNac > DateTime.Now)
            {
                throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual");
            }
        }

        //ValidarEmail
        public bool ValidarEmail(string mail)
        {
            string expresion;
            expresion = @"\A(\w+\.?\w*\@\w+\.)(com)\Z";
            System.Text.RegularExpressions.Regex automata = new Regex(expresion);
            return automata.IsMatch(mail);
        }

        


        public void ValidarSoloLetras(TextBox textBox)
        {
            string texto = textBox.Text;
            string textoValidado = string.Empty;

            // Verifica cada carácter en el texto
            foreach (char c in texto)
            {
                // Si el carácter es una letra, agrégalo al texto validado
                if (char.IsLetter(c))
                {
                    textoValidado += c;
                }
            }

            // Establece el texto validado en el TextBox
            textBox.Text = textoValidado;
            // Coloca el cursor al final del texto para mantener la posición del usuario
            textBox.SelectionStart = textBox.Text.Length;
        }


        public void ValidarSoloNumeros(TextBox textBox)
        {
            string texto = textBox.Text;
            string textoValidado = string.Empty;

            // Verifica cada carácter en el texto
            foreach (char c in texto)
            {
                // Si el carácter es un dígito, agrégalo al texto validado
                if (char.IsDigit(c))
                {
                    textoValidado += c;
                }
            }

            // Establece el texto validado en el TextBox
            textBox.Text = textoValidado;
            // Coloca el cursor al final del texto para mantener la posición del usuario
            textBox.SelectionStart = textBox.Text.Length;
        }









    }
}
