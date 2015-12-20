using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeYourself.Windows.ViewModels
{
    public class SelectLevelViewModel : ViewModelBase
    {
        private IEnumerable<string> levels;
        private string selectedSkill;

        public SelectLevelViewModel()
        {
            this.levels = new List<string>();
        }

        public IEnumerable<string> Levels
        {
            get
            {
                return this.levels;
            }

            set
            {
                // todo
                this.levels = value;
                //this.RaisePropertyChanged(() => this.SelectedSkill);
            }
        }

        public string SelectedSkill
        {
            get
            {
                return this.selectedSkill;
            }
            set
            {
                this.selectedSkill = value;
                this.RaisePropertyChanged(() => this.SelectedSkill);
            }
        }
    }
}
