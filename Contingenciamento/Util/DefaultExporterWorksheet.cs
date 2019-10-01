using Contingenciamento.Entidades;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;

namespace Contingenciamento.Util
{
    public static class DefaultExporterWorksheet
    {
        private static List<ContingencyFund> ContingencyFundsContract { get; set; }
        public static IWorkbook ExportCtgencyEmployeeList(List<ContingencyPast> cpListByMonthYear, List<ContingencyFund> contFunds, List<ContingencyAliquot> contAliquots) 
        {

            ContingencyFundsContract = new List<ContingencyFund>();
            IWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Relação de Colaboradores");
            ICreationHelper cH = wb.GetCreationHelper();
            Dictionary<string, ICellStyle> Styles = _CreateStyles(wb);
            Dictionary<int, ContingencyAliquot> IndexCellFundsPair = new Dictionary<int, ContingencyAliquot>();

            //Parte do cabeçalho
            sheet = _CreateDefaultHeader(sheet, wb, contFunds, contAliquots);
            int rowNumber = sheet.LastRowNum + 1;
            int countBodyRows = 1;
            //int staticHeaderRows = 9;
            int startDinamicCellIndex = 16; //Quando começa as colunas dinâmicas das verbas calculadas.
            int currentCellIndex = startDinamicCellIndex; //Vai aumentando o indice a medida que são incorporadas novas colunas
            //int colsNumber = 21; //Representa estaticamente o número de colunas dessa planilha (quero fazer dinâmico no futuro)

            foreach (ContingencyPast cp in cpListByMonthYear)
            {
                IRow row = sheet.CreateRow(rowNumber);

                ICell c0 = row.CreateCell(0);
                c0.SetCellType(CellType.Numeric);
                c0.SetCellValue(countBodyRows);
                c0.CellStyle = Styles["AllBorders"];
                ICell c1 = row.CreateCell(1);
                c1.SetCellValue(cH.CreateRichTextString(cp.EmployeeHistory.Employee.Name));
                c1.CellStyle = Styles["AllBorders"];
                ICell c2 = row.CreateCell(2);
                if (cp.EmployeeHistory.Employee.Role != null)
                {
                    c2.SetCellValue(cH.CreateRichTextString(cp.EmployeeHistory.Employee.Role.Name));
                }
                c2.CellStyle = Styles["AllBorders"];
                ICell c3 = row.CreateCell(3);
                if(cp.EmployeeHistory.Department != null)
                {
                    c3.SetCellValue(cH.CreateRichTextString(cp.EmployeeHistory.Department.Name));
                }
                c3.CellStyle = Styles["AllBorders"];
                ICell c4 = row.CreateCell(4);
                c4.SetCellValue(cH.CreateRichTextString("07:00"));
                c4.CellStyle = Styles["AllBorders"];
                ICell c5 = row.CreateCell(5);
                c5.SetCellValue(cH.CreateRichTextString("12:00"));
                c5.CellStyle = Styles["AllBorders"];
                ICell c6 = row.CreateCell(6);
                c6.SetCellValue(cH.CreateRichTextString("13:00"));
                c6.CellStyle = Styles["AllBorders"];
                ICell c7 = row.CreateCell(7);
                c7.SetCellValue(cH.CreateRichTextString("17:00"));
                c7.CellStyle = Styles["AllBorders"];
                ICell c8 = row.CreateCell(8);
                c8.SetCellValue(cH.CreateRichTextString(cp.EmployeeHistory.Employee.CurrentAdmissionDate.ToShortDateString()));
                c8.CellStyle = Styles["AllBorders"];
                ICell c9 = row.CreateCell(9);
                c9.SetCellValue(cH.CreateRichTextString(""));
                c9.CellStyle = Styles["AllBorders"];
                ICell c10 = row.CreateCell(10);
                c10.SetCellValue(cH.CreateRichTextString("ATIVO"));
                c10.CellStyle = Styles["AllBorders"];
                ICell c11 = row.CreateCell(11);
                c11.SetCellValue(cH.CreateRichTextString("dd/mm/yyyy a dd/mm/yyyy"));
                c11.CellStyle = Styles["AllBorders"];
                ICell c12 = row.CreateCell(12);
                c12.SetCellValue(cH.CreateRichTextString(cp.EmployeeHistory.Employee.Birthday.ToShortDateString()));
                c12.CellStyle = Styles["AllBorders"];
                ICell c13 = row.CreateCell(13);
                c13.SetCellValue(cH.CreateRichTextString(cp.EmployeeHistory.Employee.PIS.ToString()));
                c13.CellStyle = Styles["AllBorders"];
                ICell c14 = row.CreateCell(14);
                c14.SetCellValue(cH.CreateRichTextString(cp.EmployeeHistory.Employee.CPF.ToString()));
                c14.CellStyle = Styles["AllBorders"];

                ICell c15 = row.CreateCell(15);
                c15.SetCellType(CellType.Numeric);
                c15.SetCellValue(cp.EmployeeHistory.BaseSalary);
                c15.CellStyle = Styles["AllBordersCurrency"];

                //MODO ANTIGO: MANUAL
                /*
                ICell c16 = row.CreateCell(16);
                c16.SetCellType(CellType.Numeric);
                c16.SetCellValue(cp.ContingencyAliquots[1].CalculatedValue);
                c16.CellStyle = Styles["AllBordersCurrency"];
                ICell c17 = row.CreateCell(17);
                c17.SetCellType(CellType.Numeric);
                c17.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                c17.CellStyle = Styles["AllBordersCurrency"];
                ICell c18 = row.CreateCell(18);
                c18.SetCellType(CellType.Numeric);
                c18.SetCellValue(cp.ContingencyAliquots[2].CalculatedValue);
                c18.CellStyle = Styles["AllBordersCurrency"];
                ICell c19 = row.CreateCell(19);
                c19.SetCellType(CellType.Numeric);
                c19.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                c19.CellStyle = Styles["AllBordersCurrency"];
                */

                //MODO NOVO: DINÂMICO
                ICell cellFund;
                double accTotal = 0;
                currentCellIndex = startDinamicCellIndex;
                foreach (ContingencyFund cFund in ContingencyFundsContract)
                {
                    foreach (ContingencyAliquot caEmployee in cp.ContingencyAliquots)
                    {
                        if (cFund.Id == caEmployee.ContingencyFund.Id)
                        {
                            cellFund = row.CreateCell(currentCellIndex);
                            cellFund.SetCellType(CellType.Numeric);
                            cellFund.SetCellValue(caEmployee.CalculatedValue);
                            cellFund.CellStyle = Styles["AllBordersCurrency"];
                            ContingencyAliquot mapValue;
                            if (IndexCellFundsPair.TryGetValue(currentCellIndex, out mapValue))
                            {
                                mapValue.Value += caEmployee.CalculatedValue;
                            }
                            else
                            {
                                IndexCellFundsPair.Add(currentCellIndex,
                                    new ContingencyAliquot(caEmployee.CalculatedValue, new ContingencyFund(cFund.Id, cFund.Name)));
                            }

                            accTotal += caEmployee.CalculatedValue;
                            currentCellIndex++;

                        }
                    }                    
                }

                //Não vou mais usar Fórmulas pois está dando erros (a tabela deve ser dinâmica e as letras mudam, isso fica complicado)
                /*
                int fixedFormulaCell = staticHeaderRows + countBodyRows;
                ICell c20 = row.CreateCell(20);
                c20.SetCellType(CellType.Numeric);
                c20.SetCellFormula("SUM(Q"+fixedFormulaCell+":T"+fixedFormulaCell+")");
                c20.CellStyle = Styles["AllBordersCurrency"];
                */

                //Somatório MANUAL
                //double total = cp.ContingencyAliquots[0].CalculatedValue + cp.ContingencyAliquots[1].CalculatedValue + cp.ContingencyAliquots[2].CalculatedValue + cp.ContingencyAliquots[3].CalculatedValue;
                ICell totalCell = row.CreateCell(currentCellIndex);
                totalCell.SetCellValue(accTotal);
                totalCell.SetCellType(CellType.Numeric);
                totalCell.CellStyle = Styles["AllBordersCurrency"];
                ContingencyAliquot mapValueTotal;
                if (IndexCellFundsPair.TryGetValue(currentCellIndex, out mapValueTotal))
                {
                    mapValueTotal.Value += accTotal;
                }
                else
                {
                    IndexCellFundsPair.Add(currentCellIndex,
                        new ContingencyAliquot(accTotal, new ContingencyFund(-1, "TOTAL")));
                }

                rowNumber++;
                countBodyRows++;
            }

            IRow lastRow = sheet.CreateRow(rowNumber);
            //int fixedRange1 = staticHeaderRows + 1;
            //int fixedRange2 = staticHeaderRows + (countBodyRows-1);
            _CreateLastRowBasicSheet(lastRow, IndexCellFundsPair, Styles);

            //wb.Write(stream);
            return wb;
        }

        private static void _CreateLastRowBasicSheet(IRow lastRow, Dictionary<int, ContingencyAliquot> IndexCellFundsPair, Dictionary<string, ICellStyle> Styles)
        {
            ICell cell;
            foreach (var pair in IndexCellFundsPair)
            {
                cell = lastRow.CreateCell(pair.Key);
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue(pair.Value.Value);
                cell.CellStyle = Styles["AllBordersCurrencyBoldYellow"];
            }
        }

        private static ISheet _CreateDefaultHeader(ISheet sheet, IWorkbook wb, List<ContingencyFund> contFunds, List<ContingencyAliquot> contAliquots)
        {
            Dictionary<string, ICellStyle> Styles = _CreateStyles(wb);

            sheet.SetColumnWidth(0, 5 * 256);
            sheet.SetColumnWidth(1, 35 * 256);
            sheet.SetColumnWidth(2, 15 * 256);
            sheet.SetColumnWidth(3, 20 * 256);
            sheet.SetColumnWidth(4, 6 * 256);
            sheet.SetColumnWidth(5, 6 * 256);
            sheet.SetColumnWidth(6, 6 * 256);
            sheet.SetColumnWidth(7, 6 * 256);
            sheet.SetColumnWidth(8, 12 * 256);
            sheet.SetColumnWidth(9, 12 * 256);
            sheet.SetColumnWidth(10, 12 * 256);
            sheet.SetColumnWidth(11, 20 * 256);
            sheet.SetColumnWidth(12, 12 * 256);
            sheet.SetColumnWidth(13, 15 * 256);
            sheet.SetColumnWidth(14, 15 * 256);
            sheet.SetColumnWidth(15, 15 * 256);
            //as demais colunas são dinâmicas

            int rowNumber = 0;
            IRow r1 = sheet.CreateRow(rowNumber);
            ICell c1 = r1.CreateCell(0, CellType.Blank);
            ICell c2 = r1.CreateCell(1, CellType.String);
            c2.SetCellValue("EMPRESA:");
            ICell c3 = r1.CreateCell(2, CellType.String);
            c3.SetCellValue("SOLL SERVIÇOS, OBRAS E LOCAÇÕES LTDA");
            rowNumber++;

            IRow r2 = sheet.CreateRow(rowNumber);
            ICell c4 = r2.CreateCell(0, CellType.Blank);
            ICell c5 = r2.CreateCell(1, CellType.String);
            c5.SetCellValue("PROCESSO:");
            ICell c6 = r2.CreateCell(2, CellType.String);
            c6.SetCellValue("");
            rowNumber++;

            IRow r3 = sheet.CreateRow(rowNumber);
            ICell c7 = r3.CreateCell(0, CellType.Blank);
            ICell c8 = r3.CreateCell(1, CellType.String);
            c8.SetCellValue("SIGES:");
            ICell c9 = r3.CreateCell(2, CellType.String);
            c9.SetCellValue("");
            rowNumber++;

            IRow r4 = sheet.CreateRow(rowNumber);
            ICell c10 = r4.CreateCell(0, CellType.Blank);
            ICell c11 = r4.CreateCell(1, CellType.String);
            c11.SetCellValue("VIGÊNCIA:");
            ICell c12 = r4.CreateCell(2, CellType.String);
            c12.SetCellValue("");
            rowNumber++;

            IRow r5 = sheet.CreateRow(rowNumber);
            ICell c13 = r5.CreateCell(0, CellType.Blank);
            ICell c14 = r5.CreateCell(1, CellType.String);
            c14.SetCellValue("OBJETO:");
            ICell c15 = r5.CreateCell(2, CellType.String);
            c15.SetCellValue("");
            rowNumber++;

            IRow r6 = sheet.CreateRow(rowNumber);
            ICell c16 = r6.CreateCell(0, CellType.Blank);
            ICell c17 = r6.CreateCell(1, CellType.String);
            c17.SetCellValue("QUANTIDADE DE FUNCIONÁRIOS VINCULADOS AO CONTRATO:");
            ICell c18 = r6.CreateCell(2, CellType.String);
            c18.SetCellValue("");
            rowNumber++;

            IRow r7 = sheet.CreateRow(rowNumber);
            rowNumber++;
            IRow r8 = sheet.CreateRow(rowNumber);
            rowNumber++;

            String[] titles = {
            "Nº", "NOME COMPLETO", "CARGO", "LOTAÇÃO", "ENT 1", "SAÍ 1", "ENT 2", "SAÍ 2", "ADMISSÃO", "DATA NO CONTRATO",
            "SITUAÇÃO ATUAL", "PERÍODO AQUISITIVO DE FÉRIAS", "DATA DE NASC.", "PIS", "CPF", "SALÁRIO BASE"};

            IRow r9 = sheet.CreateRow(rowNumber);
            //r9.
            for (int i = 0; i < titles.Length; i++)
            {
                ICell cell = r9.CreateCell(i);
                cell.SetCellValue(titles[i]);
                cell.CellStyle = Styles["AllBordersFillRed"];
            }

            //Modo antigo - manual, ia quebrar se o contrato não tivesse esse tipo de verba
            //ICell c35 = r9.CreateCell(16, CellType.String);
            //c35.SetCellValue("FÉRIAS");
            //c35.CellStyle = Styles["AllBordersFillRed"];
            //ICell c36 = r9.CreateCell(17, CellType.String);
            //c36.SetCellValue("13º SALÁRIO");
            //c36.CellStyle = Styles["AllBordersFillRed"];
            //ICell c37 = r9.CreateCell(18, CellType.String);
            //c37.SetCellValue("FGTS + MULTA");
            //c37.CellStyle = Styles["AllBordersFillRed"];
            //ICell c38 = r9.CreateCell(19, CellType.String);
            //c38.SetCellValue("INCIDÊNCIA");
            //c38.CellStyle = Styles["AllBordersFillRed"];

            //Modo dinâmico de obter as verbas participantes do contrato
            int indexCell = titles.Length;
            bool hasCF = false;
            ICell cfCell;
            foreach (ContingencyFund cf in contFunds)
            {
                hasCF = false;
                foreach (ContingencyAliquot ca in contAliquots)
                {
                    if (cf.Id == ca.ContingencyFund.Id)
                    {
                        hasCF = true;
                        break;
                    }
                }
                if (hasCF)
                {
                    cfCell = r9.CreateCell(indexCell, CellType.String);
                    cfCell.SetCellValue(cf.Name.ToUpper());
                    //cfCell.SetCellValue(cf.Name);
                    cfCell.CellStyle = Styles["AllBordersFillRed"];
                    sheet.SetColumnWidth(indexCell, 15 * 256);
                    indexCell++;
                    ContingencyFundsContract.Add(cf);
                }
            }

            ICell totalCell = r9.CreateCell(indexCell, CellType.String);
            totalCell.SetCellValue("TOTAL");
            totalCell.CellStyle = Styles["AllBordersFillRed"];
            sheet.SetColumnWidth(indexCell, 15 * 256);

            return sheet;
        }

        private static Dictionary<String, ICellStyle> _CreateStyles(IWorkbook wb)
        {
            Dictionary<String, ICellStyle> styles = new Dictionary<string, ICellStyle>();

            IFont font1 = wb.CreateFont();
            font1.Color = IndexedColors.White.Index;
            font1.IsBold = true;
            font1.FontHeightInPoints = 14;

            //fill background in red color
            ICellStyle style1 = wb.CreateCellStyle();
            style1.FillForegroundColor = IndexedColors.Black.Index;
            style1.FillPattern = FillPattern.BigSpots;
            style1.FillBackgroundColor = IndexedColors.Red.Index;
            styles.Add("FillRed", style1);

            // Style the cell with borders all around.
            ICellStyle styleBorder = wb.CreateCellStyle();
            styleBorder.BorderBottom = BorderStyle.Thin;
            styleBorder.BottomBorderColor = IndexedColors.Black.Index;
            styleBorder.BorderLeft = BorderStyle.Thin;
            styleBorder.LeftBorderColor = IndexedColors.Black.Index;
            styleBorder.BorderRight = BorderStyle.Thin;
            styleBorder.RightBorderColor = IndexedColors.Black.Index;
            styleBorder.BorderTop = BorderStyle.Thin;
            styleBorder.TopBorderColor = IndexedColors.Black.Index;

            styles.Add("AllBorders", styleBorder);

            ICellStyle headerRedStyle = wb.CreateCellStyle();
            headerRedStyle.BorderBottom = BorderStyle.Thin;
            headerRedStyle.BottomBorderColor = IndexedColors.Black.Index;
            headerRedStyle.BorderLeft = BorderStyle.Thin;
            headerRedStyle.LeftBorderColor = IndexedColors.Black.Index;
            headerRedStyle.BorderRight = BorderStyle.Thin;
            headerRedStyle.RightBorderColor = IndexedColors.Black.Index;
            headerRedStyle.BorderTop = BorderStyle.Thin;
            headerRedStyle.TopBorderColor = IndexedColors.Black.Index;
            headerRedStyle.FillForegroundColor = IndexedColors.Red.Index;
            //headerRedStyle.FillBackgroundColor = IndexedColors.Red.Index;
            headerRedStyle.FillPattern = FillPattern.SolidForeground;
            headerRedStyle.SetFont(font1);
            styles.Add("AllBordersFillRed", headerRedStyle);

            ICellStyle headerBlueStyle = wb.CreateCellStyle();
            headerRedStyle.BorderBottom = BorderStyle.Thin;
            headerRedStyle.BottomBorderColor = IndexedColors.Black.Index;
            headerRedStyle.BorderLeft = BorderStyle.Thin;
            headerRedStyle.LeftBorderColor = IndexedColors.Black.Index;
            headerRedStyle.BorderRight = BorderStyle.Thin;
            headerRedStyle.RightBorderColor = IndexedColors.Black.Index;
            headerRedStyle.BorderTop = BorderStyle.Thin;
            headerRedStyle.TopBorderColor = IndexedColors.Black.Index;
            headerRedStyle.FillForegroundColor = IndexedColors.Grey40Percent.Index;
            headerRedStyle.FillPattern = FillPattern.SolidForeground;
            styles.Add("AllBordersFillGrey", headerRedStyle);

            ICellStyle styleCurrency = wb.CreateCellStyle();
            styleCurrency.CloneStyleFrom(styleBorder);
            styleCurrency.DataFormat = wb.CreateDataFormat().GetFormat("\"R$\"#,##0.00");
            styles.Add("AllBordersCurrency", styleCurrency);

            ICellStyle styleCurrency1 = wb.CreateCellStyle();
            styleCurrency1.CloneStyleFrom(styleCurrency);
            styleCurrency1.FillForegroundColor = IndexedColors.Yellow.Index;
            styleCurrency1.FillPattern = FillPattern.SolidForeground;
            styles.Add("AllBordersCurrencyBoldYellow", styleCurrency1);

            return styles;
        }

        public static IWorkbook ExportCtgency13SalaryEmployeeList(HashSet<ContingencyPast> cpListByYear, int year)
        {
            IWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Relação de Colaboradores");
            ICreationHelper cH = wb.GetCreationHelper();
            Dictionary<string, ICellStyle> Styles = _CreateStyles(wb);

            //Parte do cabeçalho
            sheet = _Create13SalaryDefaultHeader(sheet, wb, year);
            int rowNumber = sheet.LastRowNum + 1;
            int countBodyRows = 1;
            int staticHeaderRows = 4;

            Dictionary<Employee, List<ContingencyPast>> contPastsByMonth = _ProcessEmployeeHistoryByMonth(cpListByYear);

            foreach (KeyValuePair<Employee, List<ContingencyPast>> kvpEmpCP in contPastsByMonth)
            {
                IRow row = sheet.CreateRow(rowNumber++);

                ICell c0 = row.CreateCell(0);
                c0.SetCellType(CellType.Numeric);
                c0.SetCellValue(countBodyRows);
                c0.CellStyle = Styles["AllBorders"];
                ICell c1 = row.CreateCell(1);
                c1.SetCellValue(cH.CreateRichTextString(kvpEmpCP.Key.Name));
                c1.CellStyle = Styles["AllBorders"];

                foreach (ContingencyPast cp in kvpEmpCP.Value)
                {
                    if (cp.EmployeeHistory.Epoch.Month == 12)
                    {
                        ICell c2 = row.CreateCell(2);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(3);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 11)
                    {
                        ICell c2 = row.CreateCell(4);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(5);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 10)
                    {
                        ICell c2 = row.CreateCell(6);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(7);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 9)
                    {
                        ICell c2 = row.CreateCell(8);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(9);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 8)
                    {
                        ICell c2 = row.CreateCell(10);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(11);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 7)
                    {
                        ICell c2 = row.CreateCell(12);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(13);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 6)
                    {
                        ICell c2 = row.CreateCell(14);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(15);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 5)
                    {
                        ICell c2 = row.CreateCell(16);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(17);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 4)
                    {
                        ICell c2 = row.CreateCell(18);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(19);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 3)
                    {
                        ICell c2 = row.CreateCell(20);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(21);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 2)
                    {
                        ICell c2 = row.CreateCell(22);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(23);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }

                    else if (cp.EmployeeHistory.Epoch.Month == 1)
                    {
                        ICell c2 = row.CreateCell(24);
                        c2.SetCellType(CellType.Numeric);
                        c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
                        c2.CellStyle = Styles["AllBordersCurrency"];

                        ICell c3 = row.CreateCell(25);
                        c3.SetCellType(CellType.Numeric);
                        c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
                        c3.CellStyle = Styles["AllBordersCurrency"];
                    }
                }

                int fixedFormulaCell = staticHeaderRows + countBodyRows;
                ICell c26 = row.CreateCell(26);
                c26.SetCellType(CellType.Numeric);
                c26.SetCellFormula("SUM(C" + fixedFormulaCell + ":Z" + fixedFormulaCell + ")");
                c26.CellStyle = Styles["AllBordersCurrency"];

                countBodyRows++;
            }

            IRow lastRow = sheet.CreateRow(rowNumber);
            int fixedRange1 = staticHeaderRows + 1;
            int fixedRange2 = staticHeaderRows + (countBodyRows - 1);
            _CreateLastRow13Salary(lastRow, fixedRange1, fixedRange2, Styles);

            return wb;
        }        

        private static ISheet _Create13SalaryDefaultHeader(ISheet sheet, IWorkbook wb, int year)
        {
            Dictionary<string, ICellStyle> Styles = _CreateStyles(wb);

            sheet.SetColumnWidth(0, 5 * 256);
            sheet.SetColumnWidth(1, 35 * 256);
            sheet.SetColumnWidth(2, 11 * 256);
            sheet.SetColumnWidth(3, 11 * 256);
            sheet.SetColumnWidth(4, 11 * 256);
            sheet.SetColumnWidth(5, 11 * 256);
            sheet.SetColumnWidth(6, 11 * 256);
            sheet.SetColumnWidth(7, 11 * 256);
            sheet.SetColumnWidth(8, 11 * 256);
            sheet.SetColumnWidth(9, 11 * 256);
            sheet.SetColumnWidth(10, 11 * 256);
            sheet.SetColumnWidth(11, 11 * 256);
            sheet.SetColumnWidth(12, 11 * 256);
            sheet.SetColumnWidth(13, 11 * 256);
            sheet.SetColumnWidth(14, 11 * 256);
            sheet.SetColumnWidth(15, 11 * 256);
            sheet.SetColumnWidth(16, 11 * 256);
            sheet.SetColumnWidth(17, 11 * 256);
            sheet.SetColumnWidth(18, 11 * 256);
            sheet.SetColumnWidth(19, 11 * 256);
            sheet.SetColumnWidth(20, 11 * 256);
            sheet.SetColumnWidth(21, 11 * 256);
            sheet.SetColumnWidth(22, 11 * 256);
            sheet.SetColumnWidth(23, 11 * 256);
            sheet.SetColumnWidth(24, 11 * 256);
            sheet.SetColumnWidth(25, 11 * 256);
            sheet.SetColumnWidth(26, 11 * 256);
            sheet.SetColumnWidth(27, 14 * 256);

            int rowNumber = 0;
            IRow r0 = sheet.CreateRow(rowNumber++);
            ICell c0 = r0.CreateCell(0, CellType.String);
            c0.SetCellValue("LIBERAÇÕES DE 13º SALÁRIOS E INCIDÊNCIAS - SOLL - PERNAMBUCO - " + year);

            IRow r1 = sheet.CreateRow(rowNumber++);

            String[] titles = {
            "Nº", "NOME COMPLETO"};

            String[] funds = {"13º Salário", "Incidência"};
            String[] shortMonths = { "Dez", "Nov", "Out", "Set", "Ago", "Jul", "Jun", "Mai", "Abr", "Mar", "Fev", "Jan" };

            IRow r2 = sheet.CreateRow(rowNumber++);
            for (int i = 0; i < titles.Length; i++)
            {
                ICell cell = r2.CreateCell(i);
                cell.SetCellValue(titles[i]);
                cell.CellStyle = Styles["AllBordersFillRed"];
            }

            for (int i=0; i < 24; i++)
            {
                ICell r2Cell = r2.CreateCell(i + titles.Length);
                r2Cell.CellStyle = Styles["AllBorders"];
                if (i % 2 == 0)
                    r2Cell.SetCellValue(funds[0]);
                else
                    r2Cell.SetCellValue(funds[1]);
            }

            IRow r3 = sheet.CreateRow(rowNumber++);
          
            for (int i=0; i<shortMonths.Length*2; i=i+2)
            {
                ICell rCell = r3.CreateCell(i + titles.Length);
                ICell rOCell = r3.CreateCell(i + 1 + titles.Length);

                rCell.SetCellValue(shortMonths[i / 2] + "-" + year);
                rOCell.SetCellValue(shortMonths[i / 2] + "-" + year);
                rCell.CellStyle = Styles["AllBorders"];
                rOCell.CellStyle = Styles["AllBorders"];

            }

            return sheet;
        }

        private static Dictionary<Employee, List<ContingencyPast>> _ProcessEmployeeHistoryByMonth(HashSet<ContingencyPast> cpListByYear)
        {
            Dictionary<Employee, List<ContingencyPast>> empContPasts = new Dictionary<Employee, List<ContingencyPast>>();

            foreach (ContingencyPast cp in cpListByYear)
            {
                if (empContPasts.ContainsKey(cp.EmployeeHistory.Employee))
                {
                    empContPasts[cp.EmployeeHistory.Employee].Add(cp);
                }
                else
                {
                    List<ContingencyPast> lcp = new List<ContingencyPast>();
                    lcp.Add(cp);
                    empContPasts.Add(cp.EmployeeHistory.Employee, lcp);
                }
            }

            foreach (var keyPair in empContPasts)
            {
                keyPair.Value.Sort( (x,y) => x.EmployeeHistory.Epoch.CompareTo(y.EmployeeHistory.Epoch) );
                //sm.Sort((x, y) => x.num_of_words.CompareTo(y.num_of_words));
            }
            return empContPasts;
        }

        private static void _CreateLastRow13Salary(IRow lastRow, int fixedRange1, int fixedRange2, Dictionary<string, ICellStyle> styles)
        {
            String[] namedCells = { "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA" };

            for (int i=2; i<namedCells.Length + 2; i++)
            {
                ICell lcell = lastRow.CreateCell(i);
                lcell.SetCellType(CellType.Numeric);
                lcell.SetCellFormula("SUM("+namedCells[i-2]+fixedRange1.ToString()+":"+ namedCells[i-2]+fixedRange2.ToString()+")");
                lcell.CellStyle = styles["AllBordersCurrencyBoldYellow"];
            }
        }

        public static IWorkbook ExportCtgencyVacationEmployeeList(List<EmployeeHistory> employeeHistories, HashSet<ContingencyPast> contingencyPasts, ContingencyAliquot caInc)
        {
            IWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Relação de Colaboradores");
            ICreationHelper cH = wb.GetCreationHelper();
            Dictionary<string, ICellStyle> Styles = _CreateStyles(wb);

            //Parte do cabeçalho
            sheet = _CreateVacationDefaultHeader(sheet, wb);
            //int titlesLength = 5; //Quantidade de colunas do cabeçalho fixo (criado no método anterior)
            //int staticHeaderRows = 4;
            int rowNumber = sheet.LastRowNum + 1;
            int countBodyRows = 1;
            ContingencyFund contFund = new ContingencyFund("Férias");

            Dictionary<int, string> kvpMonths = new Dictionary<int, string>();
            kvpMonths.Add(1, "Jan"); kvpMonths.Add(2, "Fev"); kvpMonths.Add(3, "Mar"); kvpMonths.Add(4, "Abr"); kvpMonths.Add(5, "Mai"); kvpMonths.Add(6, "Jun");
            kvpMonths.Add(7, "Jul"); kvpMonths.Add(8, "Ago"); kvpMonths.Add(9, "Set"); kvpMonths.Add(10, "Out"); kvpMonths.Add(11, "Nov"); kvpMonths.Add(12, "Dez");
            String[] orderedShortMonths = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };

            Dictionary<Employee, List<ContingencyPast>> contPastsByMonth = _ProcessEmployeeHistoryByMonth(contingencyPasts);
            Dictionary<int, double> sumColumnsValues = new Dictionary<int, double>();

            foreach (EmployeeHistory eh in employeeHistories)
            {
                IRow row = sheet.CreateRow(rowNumber++);

                ICell c0 = row.CreateCell(0);
                c0.SetCellType(CellType.Numeric);
                c0.SetCellValue(countBodyRows);
                c0.CellStyle = Styles["AllBorders"];
                ICell c1 = row.CreateCell(1);
                c1.SetCellValue(cH.CreateRichTextString(eh.Employee.Name));
                c1.CellStyle = Styles["AllBorders"];
                ICell c2 = row.CreateCell(2);
                c2.SetCellValue(cH.CreateRichTextString(eh.Employee.CurrentAdmissionDate.ToShortDateString()));
                c2.CellStyle = Styles["AllBorders"];
                ICell c3 = row.CreateCell(3);
                c3.SetCellValue(cH.CreateRichTextString("dd/mm/yyyy a dd/mm/yyyy"));
                c3.CellStyle = Styles["AllBorders"];
                ICell c4 = row.CreateCell(4);
                c4.SetCellValue(cH.CreateRichTextString(eh.StartVacationTaken.ToShortDateString() +
                    " até " + eh.EndVacationTaken.ToShortDateString()));
                c4.CellStyle = Styles["AllBorders"];
                int colIndex = 5;
                int colMaxIndex = 5 + 24;
                IRow nextRow = sheet.CreateRow(rowNumber++);
                double totalAcc = 0;

                foreach (ContingencyPast cp in contingencyPasts)
                {
                    string monthYear = "";
                    if (eh.Employee.Id == cp.EmployeeHistory.Employee.Id)
                    {
                        ICell cellEpochDate = row.CreateCell(colIndex);
                        ICell cellValueCalc = nextRow.CreateCell(colIndex);
                        monthYear = kvpMonths[cp.EmployeeHistory.Epoch.Month].ToString() + "/" + cp.EmployeeHistory.Epoch.Year;

                        //Célula com o mês e cálculo das Férias
                        cellEpochDate.SetCellValue(cH.CreateRichTextString(monthYear));
                        cellEpochDate.CellStyle = Styles["AllBorders"];
                        totalAcc += cp.ContingencyAliquots[0].CalculatedValue;
                        cellValueCalc.SetCellValue(cH.CreateRichTextString(cp.ContingencyAliquots[0].CalculatedValue.ToString()));
                        cellValueCalc.CellStyle = Styles["AllBorders"];
                        if (sumColumnsValues.ContainsKey(colIndex))
                        {
                            sumColumnsValues[colIndex] += cp.ContingencyAliquots[0].CalculatedValue;
                        }
                        else
                        {
                            sumColumnsValues.Add(colIndex, cp.ContingencyAliquots[0].CalculatedValue);
                        }

                        colIndex++;
                        ICell cellEpochDateNextCol = row.CreateCell(colIndex);
                        ICell cellValueCalcNextCol = nextRow.CreateCell(colIndex);
                        //Célula da próxima coluna -> cálculo da incidência sobre as férias
                        cellEpochDateNextCol.SetCellValue(cH.CreateRichTextString(monthYear));
                        cellEpochDateNextCol.CellStyle = Styles["AllBorders"];
                        totalAcc += (cp.ContingencyAliquots[0].CalculatedValue * caInc.Value/100);
                        cellValueCalcNextCol.SetCellValue(cH.CreateRichTextString((cp.ContingencyAliquots[0].CalculatedValue * (caInc.Value/100)).ToString()));
                        cellValueCalcNextCol.CellStyle = Styles["AllBorders"];

                        if (sumColumnsValues.ContainsKey(colIndex))
                        {
                            sumColumnsValues[colIndex] += cp.ContingencyAliquots[0].CalculatedValue * (caInc.Value/100);
                        }
                        else
                        {
                            sumColumnsValues.Add(colIndex, cp.ContingencyAliquots[0].CalculatedValue * (caInc.Value/100));
                        }
                        colIndex++;
                    }
                }
                ICell totalRowCell = row.CreateCell(colMaxIndex);
                totalRowCell.SetCellValue(cH.CreateRichTextString(totalAcc.ToString()));
                totalRowCell.CellStyle = Styles["AllBorders"];
                countBodyRows++;
            }
            IRow lastRow = sheet.CreateRow(rowNumber++);
            foreach (KeyValuePair<int,double> kvpTotal in sumColumnsValues)
            {
                ICell cellLastRow = lastRow.CreateCell(kvpTotal.Key);
                cellLastRow.SetCellValue(cH.CreateRichTextString(kvpTotal.Value.ToString()));
                cellLastRow.CellStyle = Styles["AllBorders"];
            }
            //foreach (KeyValuePair<Employee, List<ContingencyPast>> kvpEmpCP in contPastsByMonth)
            //{                
                
            //    foreach (ContingencyPast cp in kvpEmpCP.Value)
            //    {
            //        //if (cp.EmployeeHistory.InVacation)
            //       // {
                        

            //            int firstMonth = cp.EmployeeHistory.StartVacationTaken.Month; //1 a 12
            //            int lastMonth = cp.EmployeeHistory.EndVacationTaken.Month;
                        
            //            //Vai ter que fazer um gingado aqui pra poder pegar os meses certinhos que compõem as férias do funcionário

            //            for (int i = 0; i < orderedShortMonths.Length * 2; i = i + 2)
            //            {
            //                ICell rCell = row.CreateCell(i + titlesLength);
            //                ICell rOCell = row.CreateCell(i + 1 + titlesLength);

            //                //rCell.SetCellValue(shortMonths[i / 2] + "-" + year);
            //                //rOCell.SetCellValue(shortMonths[i / 2] + "-" + year);
            //                rCell.CellStyle = Styles["AllBorders"];
            //                rOCell.CellStyle = Styles["AllBorders"];

            //            }

            //            IRow r3 = sheet.CreateRow(rowNumber++);

            //            //if (cp.EmployeeHistory.Epoch.Month == 12)
            //            //{
            //            //    ICell c2 = row.CreateCell(2);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(3);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 11)
            //            //{
            //            //    ICell c2 = row.CreateCell(4);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(5);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 10)
            //            //{
            //            //    ICell c2 = row.CreateCell(6);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(7);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 9)
            //            //{
            //            //    ICell c2 = row.CreateCell(8);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(9);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 8)
            //            //{
            //            //    ICell c2 = row.CreateCell(10);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(11);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 7)
            //            //{
            //            //    ICell c2 = row.CreateCell(12);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(13);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 6)
            //            //{
            //            //    ICell c2 = row.CreateCell(14);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(15);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 5)
            //            //{
            //            //    ICell c2 = row.CreateCell(16);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(17);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 4)
            //            //{
            //            //    ICell c2 = row.CreateCell(18);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(19);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 3)
            //            //{
            //            //    ICell c2 = row.CreateCell(20);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(21);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 2)
            //            //{
            //            //    ICell c2 = row.CreateCell(22);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(23);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}

            //            //else if (cp.EmployeeHistory.Epoch.Month == 1)
            //            //{
            //            //    ICell c2 = row.CreateCell(24);
            //            //    c2.SetCellType(CellType.Numeric);
            //            //    c2.SetCellValue(cp.ContingencyAliquots[0].CalculatedValue);
            //            //    c2.CellStyle = Styles["AllBordersCurrency"];

            //            //    ICell c3 = row.CreateCell(25);
            //            //    c3.SetCellType(CellType.Numeric);
            //            //    c3.SetCellValue(cp.ContingencyAliquots[3].CalculatedValue);
            //            //    c3.CellStyle = Styles["AllBordersCurrency"];
            //            //}
            //        }
            //    //}

            //    //int fixedFormulaCell = staticHeaderRows + countBodyRows;
            //    //ICell c26 = row.CreateCell(26);
            //    //c26.SetCellType(CellType.Numeric);
            //    //c26.SetCellFormula("SUM(C" + fixedFormulaCell + ":Z" + fixedFormulaCell + ")");
            //    //c26.CellStyle = Styles["AllBordersCurrency"];

            //    countBodyRows++;
            //}

            //IRow lastRow = sheet.CreateRow(rowNumber);
            //int fixedRange1 = staticHeaderRows + 1;
            //int fixedRange2 = staticHeaderRows + (countBodyRows - 1);
            //_CreateLastRow13Salary(lastRow, fixedRange1, fixedRange2, Styles);

            return wb;
        }

        private static ISheet _CreateVacationDefaultHeader(ISheet sheet, IWorkbook wb)
        {
            Dictionary<string, ICellStyle> Styles = _CreateStyles(wb);

            sheet.SetColumnWidth(0, 5 * 256);
            sheet.SetColumnWidth(1, 35 * 256);
            sheet.SetColumnWidth(2, 15 * 256);
            sheet.SetColumnWidth(3, 25 * 256);
            sheet.SetColumnWidth(4, 25 * 256);
            sheet.SetColumnWidth(5, 11 * 256);
            sheet.SetColumnWidth(6, 11 * 256);
            sheet.SetColumnWidth(7, 11 * 256);
            sheet.SetColumnWidth(8, 11 * 256);
            sheet.SetColumnWidth(9, 11 * 256);
            sheet.SetColumnWidth(10, 11 * 256);
            sheet.SetColumnWidth(11, 11 * 256);
            sheet.SetColumnWidth(12, 11 * 256);
            sheet.SetColumnWidth(13, 11 * 256);
            sheet.SetColumnWidth(14, 11 * 256);
            sheet.SetColumnWidth(15, 11 * 256);
            sheet.SetColumnWidth(16, 11 * 256);
            sheet.SetColumnWidth(17, 11 * 256);
            sheet.SetColumnWidth(18, 11 * 256);
            sheet.SetColumnWidth(19, 11 * 256);
            sheet.SetColumnWidth(20, 11 * 256);
            sheet.SetColumnWidth(21, 11 * 256);
            sheet.SetColumnWidth(22, 11 * 256);
            sheet.SetColumnWidth(23, 11 * 256);
            sheet.SetColumnWidth(24, 11 * 256);
            sheet.SetColumnWidth(25, 11 * 256);
            sheet.SetColumnWidth(26, 11 * 256);
            sheet.SetColumnWidth(27, 11 * 256);
            sheet.SetColumnWidth(28, 11 * 256);
            sheet.SetColumnWidth(29, 15 * 256);

            int rowNumber = 0;
            IRow r0 = sheet.CreateRow(rowNumber++);
            ICell c0 = r0.CreateCell(0, CellType.String);
            c0.SetCellValue("LIBERAÇÕES DE FÉRIAS E INCIDÊNCIAS - SOLL - PERNAMBUCO");

            IRow r1 = sheet.CreateRow(rowNumber++);

            String[] titles = {
            "Nº", "NOME COMPLETO", "ADMISSÃO", "PERÍODO DE GOZO", "PERÍODO AQUISITIVO"};

            String[] funds = { "Férias", "Incidência" };

            IRow r2 = sheet.CreateRow(rowNumber++);
            for (int i = 0; i < titles.Length; i++)
            {
                ICell cell = r2.CreateCell(i);
                cell.SetCellValue(titles[i]);
                cell.CellStyle = Styles["AllBordersFillGrey"];
            }

            for (int i = 0; i < 24; i++)
            {
                ICell r2Cell = r2.CreateCell(i + titles.Length);
                r2Cell.CellStyle = Styles["AllBorders"];
                if (i % 2 == 0)
                    r2Cell.SetCellValue(funds[0]);
                else
                    r2Cell.SetCellValue(funds[1]);
            }            

            return sheet;
        }

        private static void _CreateMonthsRow(ISheet sheet, int rowNumber, int titlesLength, int year, Dictionary<string, ICellStyle> Styles)
        {
            String[] shortMonths = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
            IRow r3 = sheet.CreateRow(rowNumber++);
            for (int i = 0; i < shortMonths.Length * 2; i = i + 2)
            {
                ICell rCell = r3.CreateCell(i + titlesLength);
                ICell rOCell = r3.CreateCell(i + 1 + titlesLength);

                rCell.SetCellValue(shortMonths[i / 2] + "-" + year);
                rOCell.SetCellValue(shortMonths[i / 2] + "-" + year);
                rCell.CellStyle = Styles["AllBorders"];
                rOCell.CellStyle = Styles["AllBorders"];

            }
        }
    }
}
