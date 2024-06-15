//Creado por Sebastian Febre
// https://github.com/sebafebre
using Entidades;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart = Microsoft.Office.Interop.Excel.Chart;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Globalization;
using System.Windows.Forms;





namespace Modelo
{
    public class ReportesDAL
    {

        ContextoBD con = new ContextoBD();

        #region Reporte de Reservas por día del mes
        public Dictionary<int, int> ContarReservasPorDiaDelMesActual()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime primerDiaDelMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            List<ReservaBE> reservasDelMes = con.Reserva
                .Where(r =>
                // La reserva comienza antes o durante el mes actual
                (r.FechaLlegada <= ultimoDiaDelMes && r.FechaIda >= primerDiaDelMes) ||
                // La reserva termina después o durante el mes actual
                (r.FechaIda >= primerDiaDelMes && r.FechaIda <= ultimoDiaDelMes))
                .ToList();

            Dictionary<int, int> reservasPorDia = new Dictionary<int, int>();

            for (int dia = 1; dia <= ultimoDiaDelMes.Day; dia++)
            {
                reservasPorDia.Add(dia, 0);
            }

            foreach (var reserva in reservasDelMes)
            {
                DateTime fechaInicio = reserva.FechaLlegada > primerDiaDelMes ? reserva.FechaLlegada : primerDiaDelMes;
                DateTime fechaFin = reserva.FechaIda < ultimoDiaDelMes ? reserva.FechaIda : ultimoDiaDelMes;

                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    int diaReserva = fecha.Day;
                    reservasPorDia[diaReserva]++;
                }
            }

            return reservasPorDia;
        }



        public Dictionary<int, int> ContarReservasPorDiaDelMesSeleccionado(int mes)
        {
            int añoActual = DateTime.Now.Year;
            DateTime primerDiaDelMes = new DateTime(añoActual, mes, 1);
            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            List<ReservaBE> reservasDelMes = con.Reserva
                .Where(r =>
                    (r.FechaLlegada <= ultimoDiaDelMes && r.FechaIda >= primerDiaDelMes) ||
                    (r.FechaIda >= primerDiaDelMes && r.FechaIda <= ultimoDiaDelMes))
                .ToList();

            Dictionary<int, int> reservasPorDia = new Dictionary<int, int>();

            for (int dia = 1; dia <= ultimoDiaDelMes.Day; dia++)
            {
                reservasPorDia.Add(dia, 0);
            }

            foreach (var reserva in reservasDelMes)
            {
                DateTime fechaInicio = reserva.FechaLlegada > primerDiaDelMes ? reserva.FechaLlegada : primerDiaDelMes;
                DateTime fechaFin = reserva.FechaIda < ultimoDiaDelMes ? reserva.FechaIda : ultimoDiaDelMes;

                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    int diaReserva = fecha.Day;
                    reservasPorDia[diaReserva]++;
                }
            }

            return reservasPorDia;
        }


        public void ExportarReservasPorDiaDelMesAExcel(Dictionary<int, int> reservasPorDia, int mes)
        {
            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = workbook.Sheets[1];

            // Encabezado de las columnas
            worksheet.Cells[1, 1] = "Día";
            worksheet.Cells[1, 2] = "Cantidad de Reservas";

            // Llenar los datos en el archivo Excel
            int row = 2;
            foreach (var kvp in reservasPorDia)
            {
                worksheet.Cells[row, 1] = kvp.Key; // Día
                worksheet.Cells[row, 2] = kvp.Value; // Cantidad de reservas
                row++;
            }

            // Ajustar el ancho de las columnas para que se vean mejor
            Range headerRange = worksheet.Range["A1", "B1"];
            headerRange.Columns.AutoFit();

            // Formato para las celdas y columnas
            Range dataRange = worksheet.Range["A2", "B" + row];
            dataRange.Interior.Color = XlRgbColor.rgbLightGray; // Color de fondo de los datos

            // Agregar color a las celdas de "Reservas" y "Días"
            Range headerRangeReservas = worksheet.Range["B1"];
            headerRangeReservas.Interior.Color = XlRgbColor.rgbLightCoral; // Cambia el color según tus necesidades

            Range headerRangeDias = worksheet.Range["A1"];
            headerRangeDias.Interior.Color = XlRgbColor.rgbLightCoral; // Cambia el color según tus necesidades

            // Agregar gráfico de barras
            ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects();
            ChartObject chartObject = chartObjects.Add(500, 80, 600, 400); // Tamaño del gráfico
            Chart chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlColumnClustered;

            // Establecer los datos del gráfico
            Range chartRange = worksheet.Range[worksheet.Cells[2, 2], worksheet.Cells[row, 2]]; // Rango que contiene las reservas por día
            chart.SetSourceData(chartRange);

            // Configurar los ejes
            Axis xAxis = (Axis)chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            xAxis.CategoryNames = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[row, 1]]; // Días

            // Configurar el formato del gráfico
            Series series = (Series)chart.SeriesCollection(1);
            series.Format.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); // Color de las barras

            // Seleccionar un diseño de gráfico predeterminado
            chart.ApplyLayout(2); // Cambia el número para seleccionar otro diseño de gráfico

            // Establecer el título del gráfico con el mes seleccionado
            chart.ChartTitle.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes);
            series.Name = "Reservas del Mes";
            // Nombre del archivo de Excel con la fecha actual
            string ubicacionProyecto = "SGH - UAI - Final/ArchivosHotel";
            string carpetaExcels = "Excels";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string excelDirectory = Path.Combine(desktopPath, ubicacionProyecto, carpetaExcels);
            Directory.CreateDirectory(excelDirectory);
            string excelFileName = $"ReservasPorDia_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            string excelFilePath = Path.Combine(excelDirectory, excelFileName);

            // Guardar el archivo Excel en disco
            workbook.SaveAs(excelFilePath);
            workbook.Close();
            excelApp.Quit();
        }
        #endregion



        #region Reporte de Pedidos por día del mes

        public Dictionary<int, int> ContarPedidosPorDiaDelMesSeleccionado(int mes)
        {
            int añoActual = DateTime.Now.Year;
            DateTime primerDiaDelMes = new DateTime(añoActual, mes, 1);
            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            List<PedidoBE> pedidosDelMes = con.Pedido
                .Where(p => p.FechaCreacion >= primerDiaDelMes && p.FechaCreacion<= ultimoDiaDelMes)
                .ToList();

            Dictionary<int, int> pedidosPorDia = new Dictionary<int, int>();

            for (int dia = 1; dia <= ultimoDiaDelMes.Day; dia++)
            {
                pedidosPorDia.Add(dia, 0);
            }

            foreach (var pedido in pedidosDelMes)
            {
                DateTime fechaInicio = pedido.FechaCreacion > primerDiaDelMes ? pedido.FechaCreacion : primerDiaDelMes;
                DateTime fechaFin = pedido.FechaCreacion < ultimoDiaDelMes ? pedido.FechaCreacion : ultimoDiaDelMes;

                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    int diaPedido = fecha.Day;
                    pedidosPorDia[diaPedido]++;
                }
            }

            return pedidosPorDia;
        }







        public void ExportarPedidosPorDiaDelMesAExcel(Dictionary<int, int> pedidosPorDia, int mes)
        {
            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = workbook.Sheets[1];

            // Encabezado de las columnas
            worksheet.Cells[1, 1] = "Día";
            worksheet.Cells[1, 2] = "Cantidad de Pedidos";

            // Llenar los datos en el archivo Excel
            int row = 2;
            foreach (var kvp in pedidosPorDia)
            {
                worksheet.Cells[row, 1] = kvp.Key; // Día
                worksheet.Cells[row, 2] = kvp.Value; // Cantidad de pedidos
                row++;
            }

            // Ajustar el ancho de las columnas para que se vean mejor
            Range headerRange = worksheet.Range["A1", "B1"];
            headerRange.Columns.AutoFit();

            // Formato para las celdas y columnas
            Range dataRange = worksheet.Range["A2", "B" + row];
            dataRange.Interior.Color = XlRgbColor.rgbLightGray; // Color de fondo de los datos

            // Agregar color a las celdas de "Reservas" y "Días"
            Range headerRangeReservas = worksheet.Range["B1"];
            headerRangeReservas.Interior.Color = XlRgbColor.rgbLightCoral; // Cambia el color según tus necesidades

            Range headerRangeDias = worksheet.Range["A1"];
            headerRangeDias.Interior.Color = XlRgbColor.rgbLightCoral; // Cambia el color según tus necesidades

            // Agregar gráfico de barras
            ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects();
            ChartObject chartObject = chartObjects.Add(500, 80, 600, 400); // Tamaño del gráfico
            Chart chart = chartObject.Chart;
            chart.ChartType = XlChartType.xlColumnClustered;

            // Establecer los datos del gráfico
            Range chartRange = worksheet.Range[worksheet.Cells[2, 2], worksheet.Cells[row, 2]]; // Rango que contiene las reservas por día
            chart.SetSourceData(chartRange);

            // Configurar los ejes
            Axis xAxis = (Axis)chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            xAxis.CategoryNames = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[row, 1]]; // Días

            // Configurar el formato del gráfico
            Series series = (Series)chart.SeriesCollection(1);
            series.Format.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); // Color de las barras

            // Seleccionar un diseño de gráfico predeterminado
            chart.ApplyLayout(2); // Cambia el número para seleccionar otro diseño de gráfico

            // Establecer el título del gráfico con el mes seleccionado
            chart.ChartTitle.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes);
            series.Name = "Pedidos del Mes";

            // Nombre del archivo de Excel con la fecha actual
            string ubicacionProyecto = "SGH - UAI - Final/ArchivosHotel";
            string carpetaExcels = "Excels";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string excelDirectory = Path.Combine(desktopPath, ubicacionProyecto, carpetaExcels);
            Directory.CreateDirectory(excelDirectory);
            string excelFileName = $"PedidosPorDia_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            string excelFilePath = Path.Combine(excelDirectory, excelFileName);

            // Guardar el archivo Excel en disco
            workbook.SaveAs(excelFilePath);
            workbook.Close();
            excelApp.Quit();
        }




        #endregion



        #region Grafico  frmOcupacion


        #region Metodo Chart Bastones Reservas por Dia del Mes
        public Dictionary<int, int> ContarReservasPorDiaDelMes()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime primerDiaDelMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            

            List<ReservaBE> reservasDelMes = con.Reserva
            .Where(r =>
            // La reserva comienza antes o durante el mes actual
            (r.FechaLlegada <= ultimoDiaDelMes && r.FechaIda >= primerDiaDelMes) ||
            // La reserva termina después o durante el mes actual
            (r.FechaIda >= primerDiaDelMes && r.FechaIda <= ultimoDiaDelMes))
            .ToList();

            Dictionary<int, int> reservasPorDia = new Dictionary<int, int>();

            for (int dia = 1; dia <= ultimoDiaDelMes.Day; dia++)
            {
                reservasPorDia.Add(dia, 0);
            }

            foreach (var reserva in reservasDelMes)
            {
                DateTime fechaInicio = reserva.FechaLlegada > primerDiaDelMes ? reserva.FechaLlegada : primerDiaDelMes;
                DateTime fechaFin = reserva.FechaIda < ultimoDiaDelMes ? reserva.FechaIda : ultimoDiaDelMes;

                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    int diaReserva = fecha.Day;
                    reservasPorDia[diaReserva]++;
                }
            }

            return reservasPorDia;
        }

        #endregion


        #region Metodo Chart Bastones Pedidos por Dia del Mes
        public Dictionary<int, int> ContarPedidosPorDiaDelMes()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime primerDiaDelMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            List<PedidoBE> pedidosDelMes = con.Pedido
                .Where(p => p.FechaCreacion >= primerDiaDelMes && p.FechaCreacion <= ultimoDiaDelMes)
                .ToList();

            Dictionary<int, int> pedidosPorDia = new Dictionary<int, int>();

            for (int dia = 1; dia <= ultimoDiaDelMes.Day; dia++)
            {
                pedidosPorDia.Add(dia, 0);
            }

            foreach (var pedido in pedidosDelMes)
            {
                DateTime fechaInicio = pedido.FechaCreacion > primerDiaDelMes ? pedido.FechaCreacion : primerDiaDelMes;
                DateTime fechaFin = pedido.FechaCreacion < ultimoDiaDelMes ? pedido.FechaCreacion : ultimoDiaDelMes;

                for (DateTime fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
                {
                    int diaReserva = fecha.Day;
                    pedidosPorDia[diaReserva]++;
                }
            }

            return pedidosPorDia;
        }

        #endregion


        #endregion


        






    }
}
