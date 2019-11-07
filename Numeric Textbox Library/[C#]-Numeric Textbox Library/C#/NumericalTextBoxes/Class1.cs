﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
[System.Runtime.InteropServices.ComVisible(true)]
[Description("Select properties for textbox"), Category("NumericText")]
public enum NumberFormat
{
    UnsignedInteger = 0,
    SignedInteger = 1,
    DecimalValue = 2,
    FloatValue = 3,
}

namespace NumericalTextBoxes
{
    public class NumericalTextBox : TextBox
    {
        public NumberFormat numberFormat = NumberFormat.UnsignedInteger;
        private int _input_mode = 3;
        private int _decimalNumber;
        private int _cursorPositionPlus;
        private char _groupSeparator;
        private double _maxValue;
        private double _minValue;
        private double _textValue;
        private bool _maxCheck;
        private bool _minCheck;
        private string _oldText;
        private bool usegroupseparator = false;

        System.Globalization.NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
        public static string decimalSeparator;
        private string groupSeparator;
        public static string negativeSign;
        private string positiveSign;

        public NumericalTextBox()
        {
            initializebase();
        }
        public NumericalTextBox(int DecimalNumber)
        {
            initializebase();
            _decimalNumber = (DecimalNumber >=0 && DecimalNumber <= 15) ? DecimalNumber : 15;
        }
        public NumericalTextBox(char GroupSep)
        {
            initializebase();
            _groupSeparator = (GroupSep == negativeSign[0] || GroupSep == decimalSeparator[0] || GroupSep == 'e' || GroupSep == 'E') ? groupSeparator[0] : GroupSep;
        }
        public NumericalTextBox(int DecimalNumber, char GroupSep)
        {
            initializebase();
            _decimalNumber = (DecimalNumber >= 0 && DecimalNumber <= 15) ? DecimalNumber : 15;
            _groupSeparator = (GroupSep == negativeSign[0] || GroupSep == decimalSeparator[0] || GroupSep == 'e' || GroupSep == 'E') ? groupSeparator[0] : GroupSep;
        }
        private void initializebase()
        {
            decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            groupSeparator = numberFormatInfo.NumberGroupSeparator;
            negativeSign = numberFormatInfo.NegativeSign;
            positiveSign = numberFormatInfo.PositiveSign;
            _decimalNumber = 15;
            _groupSeparator = groupSeparator[0];
            _maxValue = 0;
            _minValue = 0;
            _maxCheck = false;
            _minCheck = false;
            _oldText = "";
        }
        [Description("Select input type for textbox"), Category("NumericText")]
        public NumberFormat NumberFormat
        {
            get { return numberFormat; }
            set
            {
                _input_mode = (int)value;
                numberFormat = value;
                _oldText = "";
                OnTextChanged(new EventArgs());
            }
        }
        [Description("enable or disable thousands separator"), Category("NumericText")]
        public bool Usegroupseparator
        {
            get { return usegroupseparator; }
            set { usegroupseparator = value; _oldText = ""; OnTextChanged(new EventArgs()); }
        }
        [Description("digit count after decimal separator"), Category("NumericText")]
        public int DecimalNumber
        {
            get { return _decimalNumber; }
            set {
                    _decimalNumber = (value >=0 && value < 16) ? value : 15;
                    _oldText = "";
                    OnTextChanged(new EventArgs());
                }
        }
        [Description("Select thousands separator char except < e E > and local decimal separator, negativeSign"), Category("NumericText")]
        public char Groupsep
        {
            get { return _groupSeparator; }
            set
            {
                _groupSeparator = (value == negativeSign[0] || value == decimalSeparator[0] || value == 'e' || value == 'E') ? groupSeparator[0] : value;
                _oldText = "";
                OnTextChanged(new EventArgs());
            }
        }
        [Description("Maximum value in textbox"), Category("NumericText")]
        public double MaxValue
        {
            get { return _maxValue; }
            set
            {
                if (_maxValue != value)
                {
                    _maxValue = (value >= _minValue) ? value : _maxValue;
                    if (_maxCheck && _textValue > _maxValue)
                        Text = _maxValue.ToString(); 
                }

            }
        }
        [Description("Minimum value in textbox"), Category("NumericText")]
        public double MinValue
        {
            get { return _minValue; }
            set
            {
                if (_minValue != value)
                {
                    _minValue = (value <= _maxValue) ? value : _minValue;
                    if (_minCheck && _textValue < _minValue)
                        Text = _minValue.ToString();
                }
            }
        }
        [Description("Enable or disable Maximum value control"), Category("NumericText")]
        public bool MaxCheck
        {
            get { return _maxCheck; }
            set
            {
                _maxCheck = value;
                if (_maxCheck && _textValue > _maxValue)
                    Text = _maxValue.ToString();
            }
        }
        [Description("Enable or disable Minimum value control"), Category("NumericText")]
        public bool MinCheck
        {
            get { return _minCheck; }
            set
            {
                _minCheck = value;
                if (_minCheck && _textValue < _minValue)
                    Text = _minValue.ToString();
            }
        }
        [Description("Shows Numerictextbox value"), Category("NumericText")]
        public double NumericValue
        {
            get { return _textValue; }
            
        }
        public override bool Multiline //single line only
        {
            get { return false; }
           
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (!string.Equals(this.Text, _oldText)) //change only, if this method not changed this Text
            {                                        // avoid twice execution
                _cursorPositionPlus = 0;
                int SelectionStart = this.SelectionStart;
                int TextLength = this.Text.Length;
                int CursorPositionPlus;
                string Text = NormalTextToNumericString();
                CursorPositionPlus = _cursorPositionPlus;
                if ((!_maxCheck || _textValue <= _maxValue) && (!_minCheck || _textValue >= _minValue))
                {
                    this.Text = _oldText = Text;
                    this.SelectionStart = SelectionStart + CursorPositionPlus;
                }
                else
                {
                    this.Text = _oldText;
                }
            }
            base.OnTextChanged(e);
        }
        protected string NormalTextToNumericString()
        {
            string Text = this.Text;
            string TextTemp1 = "", TextTemp2 = "";
            #region Lowering Characters
            TextTemp1 = Text.ToLower();
            #endregion
            #region Remove Unknown Characters
            int FloatNumber = 0;
            char ds = decimalSeparator[0];
            char ns = negativeSign[0];
            for (int i = 0; i < TextTemp1.Length; i++)
                if (_input_mode > 0 && i == 0 && TextTemp1.IndexOf(negativeSign) == 0)
                    TextTemp2 += TextTemp1[i];
                else if (TextTemp1[i] == '0' && (TextTemp2 == "0" || TextTemp2 == ns + "0"))
                { // dont allow extra zeroes at begining
                    if (i < this.SelectionStart) _cursorPositionPlus--;
                }
                else if (_input_mode > 2 && TextTemp1[i] == ns && TextTemp2.IndexOf('e') >= 0 && TextTemp2.Length == TextTemp2.IndexOf('e') + 1)
                    TextTemp2 += TextTemp1[i];
                else if (char.IsDigit(TextTemp1[i]))
                {
                    if ((TextTemp2 == "0" || TextTemp2 == ns + "0") && TextTemp1[i] != '0')
                    { // remove zero at begining or after negative sign
                        TextTemp2 = TextTemp2.Remove(TextTemp2 == "0" ? 0 : 1, 1);
                        if (i < this.SelectionStart) _cursorPositionPlus--;
                    }
                    TextTemp2 += TextTemp1[i];
                    if (TextTemp2.IndexOf(ds) > -1 && TextTemp2.IndexOf('e') < 0 && i < this.SelectionStart)
                    {
                        FloatNumber++;
                        if (FloatNumber > _decimalNumber && i < this.SelectionStart)
                            _cursorPositionPlus--;
                    }
                }
                else if (_input_mode > 1 && TextTemp1[i] == ds && TextTemp2.IndexOf(ds) < 0 && (TextTemp2.IndexOf('e') < 0 || TextTemp2.Length < TextTemp2.IndexOf('e')))
                    TextTemp2 += TextTemp1[i];
                else if (_input_mode > 2 && TextTemp1[i] == 'e' && TextTemp2.IndexOf('e') < 0 && TextTemp2.Length >= TextTemp2.IndexOf(decimalSeparator) + 1)
                    TextTemp2 += TextTemp1[i];
                else if (i < this.SelectionStart)
                    _cursorPositionPlus--;
            #endregion
            #region Get Integer Number
            _textValue = txttoDouble(TextTemp2); //obtain value
            string INTEGER = "";
            int IntegerIndex = (TextTemp2.IndexOf(ds) >= 0) ? TextTemp2.IndexOf(ds) : (TextTemp2.IndexOf('e') >= 0) ? TextTemp2.IndexOf('e') : TextTemp2.Length;
            for (int i = 0; i < IntegerIndex; i++)
                if (char.IsDigit(TextTemp2[i]) || TextTemp2[i] == negativeSign[0] && INTEGER.IndexOf(negativeSign) < 0)
                    INTEGER += TextTemp2[i];
            #endregion
            #region Get Float Number
            string FLOAT = "";
            if (TextTemp2.IndexOf(ds) >= 0)
                for (int i = TextTemp2.IndexOf(ds) + 1; i < ((TextTemp2.IndexOf('e') >= 0) ? TextTemp2.IndexOf('e') : TextTemp2.Length); i++)
                    if (char.IsDigit(TextTemp2[i]))
                        FLOAT += TextTemp2[i];
            #endregion
            #region Put group separator in Integer Number
            string T = "";
            if (!usegroupseparator)
            {
                T = INTEGER;
            }
            else
            {
                int n = 0;
                for (int i = INTEGER.Length - 1; i >= 0; i--)
                {
                    T = INTEGER[i] + T;
                    n++;
                    if (n == 3 && i > 0 && INTEGER[i - 1] != negativeSign[0])
                    {
                        if (i - _cursorPositionPlus < this.SelectionStart)
                            _cursorPositionPlus++;
                        T = _groupSeparator.ToString() + T;
                        n = 0;
                    }
                }
            }
            #endregion
            #region Put decimal Character and decimals
            if (TextTemp2.IndexOf(ds) >= 0)
            {
                T += decimalSeparator;
                for (int i = 0; i < DecimalNumber && i < FLOAT.Length; i++)
                    T += FLOAT[i];
            }
            #endregion
            #region Put 'e' Character and digits
            if (TextTemp2.IndexOf('e') >= 0)
            {
                T += ('e').ToString();
                for (int i = TextTemp2.IndexOf('e') + 1; i < TextTemp2.Length; i++)
                    T += TextTemp2[i];
            }
            #endregion
            return T;
        }
        protected double txttoDouble(string txt)
        {
            if (txt == "")
                return 0;
            if (txt == negativeSign)
                return 0;
            if (txt == negativeSign + decimalSeparator)
                return 0;
            if (txt.StartsWith(negativeSign + "e"))
                return 0;
            if (txt.StartsWith("e"))
                return 0;
            if (txt.EndsWith("e") || txt.EndsWith("e" + negativeSign))
                return System.Convert.ToDouble(txt.Substring(0, txt.IndexOf('e')));
            return System.Convert.ToDouble(txt);
        }
    }
}
