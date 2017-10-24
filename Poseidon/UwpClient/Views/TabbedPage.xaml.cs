using System;
using UwpClient.Services;
using UwpClient.ViewModels;


using Windows.UI.Xaml.Controls;

namespace UwpClient.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel
        {
            get { return DataContext as TabbedViewModel; }
        }

        public TabbedPage()
        {
            InitializeComponent();
        }

        private void SemesterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            var name = comboBoxItem.Name as string;
            if (name != null && name.Equals("FirstSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre
                SubjectService.GetSubjectsBySemester(1);
            }
            else if(name != null && name.Equals("SecondSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre
                SubjectService.GetSubjectsBySemester(2);
            }
            else if (name != null && name.Equals("ThirdSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre
                SubjectService.GetSubjectsBySemester(3);
            }
            else if (name != null && name.Equals("FourthSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre
                SubjectService.GetSubjectsBySemester(4);
            }
            else if (name != null && name.Equals("FifthSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre
                SubjectService.GetSubjectsBySemester(5);
            }
            else if (name != null && name.Equals("SixthSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre
                SubjectService.GetSubjectsBySemester(6);
            }
            else if (name != null && name.Equals("SeventhSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre
                SubjectService.GetSubjectsBySemester(7);
            }
        }
    }
}
