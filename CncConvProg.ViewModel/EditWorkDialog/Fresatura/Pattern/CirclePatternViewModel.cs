﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using CncConvProg.Model.ConversationalStructure.Lavorazioni.Fresatura.Pattern;
using CncConvProg.ViewModel.AuxViewModel;
using CncConvProg.ViewModel.EditWorkDialog.TreeViewViewModel;

namespace CncConvProg.ViewModel.EditWorkDialog.Fresatura.Pattern
{
    public class CirclePatternViewModel : EditStageTreeViewItem, IDataErrorInfo, IValid
    {
        private readonly CirclePattern _patternCerchio;

        public CirclePatternViewModel(CirclePattern patternCerchio, EditStageTreeViewItem parent)
            : base("Circle", parent)
        {
            _patternCerchio = patternCerchio;
        }

        public double CentroX
        {
            get
            {
                return _patternCerchio.CentroX;
            }

            set
            {
                if (_patternCerchio.CentroX == value) return;

                _patternCerchio.CentroX = value;

                OnPropertyChanged("CentroX");
            }
        }
        public double CentroY
        {
            get
            {
                return _patternCerchio.CentroY;
            }

            set
            {
                _patternCerchio.CentroY = value;
                OnPropertyChanged("CentroY");
            }
        }
        public double Raggio
        {
            get
            {
                return _patternCerchio.Raggio;
            }

            set
            {
                _patternCerchio.Raggio = value;
                OnPropertyChanged("Raggio");
            }
        }

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return GetValidationError(propertyName); }
        }

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get { return ValidatedProperties.All(property => GetValidationError(property) == null); }
        }

        protected string[] ValidatedProperties = {
                                                    "Raggio",
                                                 };

        protected string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Raggio":
                    {
                        error = InputCheck.MaggioreDiZero(Raggio.ToString());
                    }
                    break;

                default:
                    Debug.Fail("Unexpected property : " + propertyName);
                    break;
            }

            return error;
        }

        #endregion


    }


}

