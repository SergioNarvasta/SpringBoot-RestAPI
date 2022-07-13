using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.ViewModels
{
    public class GoogleCharts
    {
        public List<ChartColumn> cols = new List<ChartColumn>();
        public List<ChartRow> rows = new List<ChartRow>();
        public struct ChartColumn
        {
            public string id;
            public string label;
            public string pattern;
            public string type;
            public string role;
        }
        public struct ChartRow
        {
            public List<ChartRowValue> c;
        }
        public struct ChartRowValue
        {
            public object v;
            public object f;
        }
        public void AddColumn(ChartColumn col) { cols.Add(col); }
        public void AddRow(ChartRow row) { rows.Add(row); }


        //================================ 
        public static bool ValidateIdentificationDocumentPeru(string identificationDocument)
        {
            if (!string.IsNullOrEmpty(identificationDocument))
            {
                int addition = 0;
                int[] hash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int identificationDocumentLength = identificationDocument.Length;

                string identificationComponent = identificationDocument.Substring(0, identificationDocumentLength - 1);

                int identificationComponentLength = identificationComponent.Length;

                int diff = hash.Length - identificationComponentLength;

                for (int i = identificationComponentLength - 1; i >= 0; i--)
                {
                    addition += (identificationComponent[i] - '0') * hash[i + diff];
                }

                addition = 11 - (addition % 11);

                if (addition == 11)
                {
                    addition = 0;
                }

                char last = char.ToUpperInvariant(identificationDocument[identificationDocumentLength - 1]);

                if (identificationDocumentLength == 11)
                {
                    // The identification document corresponds to a RUC.
                    return addition.Equals(last - '0');
                }
                else if (char.IsDigit(last))
                {
                    // The identification document corresponds to a DNI with a number as verification digit.
                    char[] hashNumbers = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                    return last.Equals(hashNumbers[addition]);
                }
                else if (char.IsLetter(last))
                {
                    // The identification document corresponds to a DNI with a letter as verification digit.
                    char[] hashLetters = { 'K', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                    return last.Equals(hashLetters[addition]);
                }
            }

            return false;
        }
    }
}