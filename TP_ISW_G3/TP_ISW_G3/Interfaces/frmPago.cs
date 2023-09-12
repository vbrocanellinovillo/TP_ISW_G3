using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_ISW_G3.Control;

namespace TP_ISW_G3.Interfaces
{
    public partial class frmPago : Form
    {

        private gestorLoQueSea gestor;

        // Variables para guardar los valores de las cajas de texto
        private string maskedText1Value = "";
        private string maskedText2Value = "";
        private string maskedText3Value = "";
        private string maskedText4Value = "";

        // Estilo cantidad efectivo
        private bool cantidadEfectivoValid = false;
        private bool cantidadEfectivoTouched = false;

        // Estilo nro tarjeta
        private bool nrtoTarjetaTouched = false;
        private bool nroTarjetaValid = false;

        // Estilo nombre titular
        private bool nombreTitularTouched = false;
        private bool nombreTitularValid = false;

        // Estilo codigo seguridad
        private bool cvcTouched = false;
        private bool cvcValid = false;

        // Estilo fecha vencimiento
        private bool dateTouched = false;
        private bool dateValid = false;


        public frmPago(Control.gestorLoQueSea gestorLoQueSea)
        {
            InitializeComponent();
            gestor = gestorLoQueSea;
        }

        public void cargarCombo()
        {
            cmbMediosPago.Items.Clear();
            cmbMediosPago.Items.Add("Efectivo");
            cmbMediosPago.Items.Add("Tarjeta Credito - Visa");
        }


        // Ajustar labels y textboxs según la selección del combo
        public void mostrarPagoEfectivo()
        {
            panel1.BackgroundImage = Properties.Resources.panelEfectivo3;
            maskedTextBox2.Enabled = false;

            maskedTextBox4.Visible = false;
            maskedTextBox3.Visible = false;

            label11.Visible = false;
            label14.Visible = false;
        }

        public void mostrarPagoTarjeta()
        {
            panel1.BackgroundImage = Properties.Resources.panelTarjeta;
            maskedTextBox2.Enabled = true;
            maskedTextBox2.Mask = "";

            maskedTextBox4.Visible = true;

            maskedTextBox3.Visible = true;

            label11.Visible = false;
        }

        // Limpiar variables y cajas de texto
        public void resetTxts()
        {
            // Cajas de texto
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";

            // Valores sacados de las cajas de texto
            maskedText1Value = "";
            maskedText2Value = "";
            maskedText3Value = "";
            maskedText4Value = "";

            // Nro de tarjeta
            nroTarjetaValid = false;
            nrtoTarjetaTouched = false;

            // Nombre titular
            nombreTitularValid = false;
            nombreTitularTouched = false;

            // Fecha vencimiento
            dateValid = false;
            dateTouched = false;

            // Codigo de seguridad
            cvcValid = false;
            cvcTouched = false;

            // Mensajes de error
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;

            // Poner el color de las cajas de texto en blanco
            maskedTextBox1.BackColor = gestor.clearErrorColor();
            maskedTextBox2.BackColor = gestor.clearErrorColor();
            maskedTextBox3.BackColor = gestor.clearErrorColor();
            maskedTextBox4.BackColor = gestor.clearErrorColor();

            // No importa
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        // Evento que se ejecuta cuando cambia la selección del combo
        private void cmbMediosPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar labels y textboxs, y habilitar el boton para pagar
            panel1.Visible = true;
            btnPagar.Enabled = true;

            resetTxts();

            if (cmbMediosPago.SelectedIndex == 0)
            {
                mostrarPagoEfectivo();
            }
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                mostrarPagoTarjeta();
            }
        }

        private void frmPago_Load(object sender, EventArgs e)
        {
            cargarCombo();
            // Agregarle el signo $ a eso despues sin que rompa el parseo despues
            lblTotal.Text = "$" + gestor.devolverTotal();

            resetTxts();
        }


        public void validarEfectivo()
        {
            double efectivo;
            if (double.TryParse(maskedText1Value, out efectivo))
            {
                // Si el monto ingresado es menor al total no es valido
                if (efectivo < Convert.ToDouble(gestor.devolverTotal()))
                {
                    cantidadEfectivoValid = false;
                    label11.Text = "*Por favor ingrese un monto mayor o igual al total";
                    return;
                }

                // Si es mayor o igual es valido
                cantidadEfectivoValid = true;
                return;
            } else
            {
                // Si llego aca es porque hubo un error de parseo porque se ingreso mal el formato
                cantidadEfectivoValid = false;
                label11.Text = "*Por favor ingrese un monto valido";
            }

        }

        public void estiloCantidadEfectivo()
        {
            // Si no es valido y si ya fue seleccionado por primera vex el textbox (para que no empieze mostrando mensaje de error)
            if (!cantidadEfectivoValid && cantidadEfectivoTouched)
            {
                // Mensaje de error
                label11.Visible = true;
                // Color del mensaje de error
                label11.ForeColor = gestor.setErrorText();
                
                // Color de la caja de texto
                maskedTextBox1.BackColor = gestor.setErrorColor();
            }
            else
            {
                // Ocultar mensaje de error
                label11.Visible = false;

                // Poner caja de texto en blanco
                maskedTextBox1.BackColor = gestor.clearErrorColor();
            }
        }

        
        public void validarNumeroTarjeta() 
        {
            // Manejo de error de indice fuera de rango si no se ingresa nro de tarjeta
            if (maskedText1Value.Trim().Length == 0)
            {
                label11.Text = "*Numero de tarjeta invalido";
                return;
            }

            // Revisar ese 12 despues
            if (maskedText1Value[0].ToString() == "4" && maskedText1Value.Trim().Length >= 12 )
            {
                nroTarjetaValid = true;
                return;
            }

            nroTarjetaValid = false;
            label11.Text = "*Numero de tarjeta invalido";
            return;
        }

        public void estiloNumeroTarjeta()
        {
            if (!nroTarjetaValid && nrtoTarjetaTouched)
            {
                label11.Visible = true;
                label11.ForeColor = gestor.setErrorText();

                maskedTextBox1.BackColor = gestor.setErrorColor();
            }
            else
            {
                label11.Visible = false;

                maskedTextBox1.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento que se ejecuta cada vez que cambia la entrada en el textbox (en este caso en el primero)
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

            // Selecciona efectivo
            if (cmbMediosPago.SelectedIndex == 0)
            {
                // Tomo el valor de la caja de texto
                maskedText1Value = maskedTextBox1.Text;

                // Calcular el vuelto a devolver
                double total = Convert.ToDouble(gestor.devolverTotal());

                double vuelto = -1;

                if (maskedText1Value.Trim().Length > 0)
                {
                    // Validación extra del formato del valor ingresado
                    double montoIngresado;

                    if (double.TryParse(maskedText1Value, out montoIngresado))
                    {
                        vuelto = montoIngresado - total;
                        // Si el vuelto es positivo se muestra, sino no se muestra nada
                        maskedTextBox2.Text = (vuelto >= 0) ? vuelto.ToString() : "";

                        validarEfectivo();
                        estiloCantidadEfectivo();

                    }
                    else
                    {
                        cantidadEfectivoValid = false;
                    }
                }

            }

            // Selecciono pago con tarjeta
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                maskedText1Value = maskedTextBox1.Text;

                validarNumeroTarjeta();
                estiloNumeroTarjeta();
            }
        }

        // Evento que se ejecuta cuando la caja de texto pierde el foco
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            // Selecciono efectivo
            if (cmbMediosPago.SelectedIndex == 0)
            {
                cantidadEfectivoTouched = true;
                validarEfectivo();
                estiloCantidadEfectivo();

                nrtoTarjetaTouched = false;
            }
            // Selecciono tarjeta
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                cantidadEfectivoTouched = false;

                nrtoTarjetaTouched = true;
                validarNumeroTarjeta();
                estiloNumeroTarjeta();

            }
        }

        public void validarNombreTitular()
        {
            // Expresión reguñar para que ingrese solo texto en el nombre del titular
            // No se si tiene que ser asi
            string patron = @"^[A-Za-záéíóúÁÉÍÓÚñÑ\s]+$";

            if (Regex.IsMatch(maskedText2Value, patron))
            {
                nombreTitularValid = true;
                return;
            }
            else
            {
                nombreTitularValid = false;
                label12.Text = "*Por favor ingrese un nombre valido";
                return;
            }
        }

        public void estiloNombreTitular()
        {
            if (!nombreTitularValid && nombreTitularTouched)
            {
                label12.Visible = true;
                label12.ForeColor = gestor.setErrorText();

                maskedTextBox2.BackColor = gestor.setErrorColor();
            }
            else
            {
                label12.Visible = false;

                maskedTextBox2.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento cambio de valor en el textbox del nombre del titular
        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            maskedText2Value = maskedTextBox2.Text.Trim();

            if (cmbMediosPago.SelectedIndex == 1)
            {
                validarNombreTitular();
                estiloNombreTitular();
            }
        }

        // Evento cuando se desenfoca el nombre del titular
        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            if (cmbMediosPago.SelectedIndex == 0)
            {
                nombreTitularTouched = false;
                validarNombreTitular();
                estiloNombreTitular();

            }
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                nombreTitularTouched = true;
                validarNombreTitular();
                estiloNombreTitular();
            }
        }

        public void validarCvc()
        {
            // Debe ingresar un codigo de seguridad de 3 digitos
            if (maskedText3Value.Trim().Length < 3)
            {
                cvcValid = false;
                label13.Text = "*Por favor ingrese un codigo de seguridad valido";
                return;
            }

            cvcValid = true;
            return;
        }

        public void estiloCvc()
        {
            if (!cvcValid && cvcTouched)
            {
                label13.Visible = true;
                label13.ForeColor = gestor.setErrorText();

                maskedTextBox3.BackColor = gestor.setErrorColor();
            }
            else
            {
                label13.Visible = false;

                maskedTextBox3.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento cuando cambia el valor del textbox del codigo de seguridad
        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            maskedText3Value = maskedTextBox3.Text.Trim();
            validarCvc();
            estiloCvc();
        }

        // Evento cuando se desenfoca el textbox del codigo de seguridad
        private void maskedTextBox3_Leave(object sender, EventArgs e)
        {
            cvcTouched = true;
            validarCvc();
            estiloCvc();
        }

        // Despues revisar esta validación no termina de funcionar muy bien
        public void validarFechaVencimiento()
        {
            // Datos de la fecha actual
            int añoActual = DateTime.Now.Year;
            int mesActual = DateTime.Now.Month;

            // Si no escribre la fecha entera no es valido
            if (maskedText4Value.Length != 7)
            {
                dateValid = false;
                label14.Text = "*Por favor ingrese la fecha completa";
                return;
            }

            // Para manejar errores de parseo
            if (!int.TryParse(maskedText4Value.Substring(0, 2), out int mes) || !int.TryParse(maskedText4Value.Substring(3, 4), out int año))
            {
                dateValid = false;
                label14.Text = "*Por favor ingrese una fecha valida";
                return;
            }

            // Que ingrese un mes detro del rango de meses de un año
            if (mes < 1 || mes > 12)
            {
                dateValid = false;
                label14.Text = "*Por favor ingrese un mes valido (entre 01 y 12)";
                return;
            }

            // Que no ingrese un año anterior al actual
            if (año < añoActual)
            {
                dateValid = false;
                label14.Text = "*Fecha de vencimiento invalida (año menor al acutal)";
                return;
            }

            // Si ingresa el año actual, que el mes no sea mayor o igual al actual
            if (año == añoActual && mes < mesActual)
            {
                dateValid = false;
                label14.Text = "¨*Fecha de vencimiento invalida (año actual, mes mayor al actual)";
                return;
            }

            // Si llego hasta aca paso todas las validaciones
            dateValid = true;
            return;
        }

        public void estiloFechaVencimiento()
        {
            if (!dateValid && dateTouched)
            {
                label14.Visible = true;
                label14.ForeColor = gestor.setErrorText();

                maskedTextBox4.BackColor = gestor.setErrorColor();
            }
            else
            {
                label14.Visible = false;

                maskedTextBox4.BackColor = gestor.clearErrorColor();
            }
        }

        // Evento que se ejecuta cuando cambia un valor en la fecha de vencimiento
        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            maskedText4Value = maskedTextBox4.Text;
            validarFechaVencimiento();
            estiloFechaVencimiento();
        }

        // Evento que se ejecuta cuando se desenfoca la caja de texto de la fecha de vencimiento
        private void maskedTextBox4_Leave(object sender, EventArgs e)
        {
            dateTouched = true;
            validarFechaVencimiento();
            estiloFechaVencimiento();
        }

        // Evento click en el boton de pagar
        private void btnPagar_Click(object sender, EventArgs e)
        {
            // Validaciones si selecciono pago en efectivo
            if (cmbMediosPago.SelectedIndex == 0)
            {
                if (!cantidadEfectivoValid)
                {
                    MessageBox.Show("Por favor ingrese un monto valido");
                    cantidadEfectivoTouched = true;
                    validarEfectivo();
                    estiloCantidadEfectivo();
                    maskedTextBox1.Focus();
                    return;
                }
            }
            // Validaciones si selecciono pago con tarjeta
            else if (cmbMediosPago.SelectedIndex == 1)
            {
                if (!nroTarjetaValid)
                {
                    MessageBox.Show("Por favor ingrese un numero de tarjeta valido");
                    nrtoTarjetaTouched = true;
                    validarNumeroTarjeta();
                    estiloNumeroTarjeta();
                    maskedTextBox1.Focus();
                    return;
                }

                if (!nombreTitularValid)
                {
                    MessageBox.Show("Por favor ingrese un nombre de titular valido");
                    nombreTitularTouched = true;
                    validarNombreTitular();
                    estiloNombreTitular();
                    maskedTextBox2.Focus();
                    return;
                }

                if (!dateValid)
                {
                    MessageBox.Show("Por favor ingrese fecha de vencimiento valida");
                    dateTouched = true;
                    validarFechaVencimiento();
                    estiloFechaVencimiento();
                    maskedTextBox4.Focus();
                    return;
                }

                if (!cvcValid)
                {
                    MessageBox.Show("Por favor ingrese un codigo de seguridad valido");
                    cvcTouched = true;
                    validarCvc();
                    estiloCvc();
                    maskedTextBox3.Focus();
                    return;
                }
            }

            // Si llego hasta aca paso todas las validaciones
            resetTxts();
            gestor.crearFormEntrega();

        }

    }
}