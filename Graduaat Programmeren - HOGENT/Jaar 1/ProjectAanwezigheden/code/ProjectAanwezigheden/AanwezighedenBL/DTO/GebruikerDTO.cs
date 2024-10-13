using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AanwezighedenBL.DTO
{
    public class GebruikerDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Familienaam { get; set; }
        public string Email { get; set; }

        private bool _isAanwezig;
        public bool IsAanwezig {
            get => _isAanwezig;
            set {
                if (_isAanwezig != value) {
                    _isAanwezig = value;
                    OnPropertyChanged(nameof(IsAanwezig));
                    if (_isAanwezig) {
                        Reden = null; 
                    }
                }
            }
        }


        private string _reden;
        public string Reden
        {
            get => _reden;
            set
            {
                if (_reden != value)
                {
                    _reden = value;
                    OnPropertyChanged(nameof(Reden));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public GebruikerDTO(int id, string naam, string familienaam, string email, bool isAanwezig, string reden)
        {
            Id = id;
            Naam = naam;
            Familienaam = familienaam;
            Email = email;
            IsAanwezig = isAanwezig;
            Reden = reden;
        }
    }
}
