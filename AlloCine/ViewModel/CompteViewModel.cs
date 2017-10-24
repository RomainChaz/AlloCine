using AlloCine.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSFilms.Models.Entity;
using System.Windows.Input;

namespace AlloCine.ViewModel
{
    public class CompteViewModel : ViewModelBase
    {

        public ICommand BtnRecherche { get; private set; }
        public ICommand BtnModifyCompteCommand { get; private set; }
        public ICommand BtnClearCompteCommand { get; private set; }
        public ICommand BtnAddCompteCommand { get; private set; }
        private T_E_COMPTE_CPT _compteSearch;
        public T_E_COMPTE_CPT CompteSearch
        {
            get { return _compteSearch; }
            set
            {
                _compteSearch = value;
                RaisePropertyChanged();
            }
        }

        public CompteViewModel()
        {
            BtnRecherche = new RelayCommand(ActionGetData);
            BtnModifyCompteCommand = new RelayCommand(ActionUpdateData);
            BtnClearCompteCommand = new RelayCommand(ActionCleanData);
            BtnAddCompteCommand = new RelayCommand(ActionNewData);
            _compteSearch = new T_E_COMPTE_CPT();
        }

        private async void ActionUpdateData()
        {
            await WSService.updateCompte(_compteSearch);
        }

        private void ActionCleanData()
        {
            CompteSearch = new T_E_COMPTE_CPT();
        }

        private async void ActionNewData()
        {

        }
        private async void ActionGetData()
        {
            CompteSearch = await WSService.getCompteByMailAsync(_compteSearch.CPT_MEL);
        }
    }
}
