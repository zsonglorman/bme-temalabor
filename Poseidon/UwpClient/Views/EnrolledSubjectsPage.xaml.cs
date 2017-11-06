﻿using Interfaces;
using System;
using System.Collections.ObjectModel;
using Telerik.UI.Xaml.Controls.Grid;
using UwpClient.Models;
using UwpClient.Services;
using UwpClient.ViewModels;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpClient.Views
{
    public sealed partial class EnrolledSubjectsPagePage : Page
    {
        private EnrolledSubjectsPageViewModel ViewModel
        {
            get { return DataContext as EnrolledSubjectsPageViewModel; }
        }

        // TODO WTS: Change the grid as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public EnrolledSubjectsPagePage()
        {
            InitializeComponent();
        }

        public Subject row;
        private void EnrolledGrid_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var physicalPoint = e.GetCurrentPoint(sender as RadDataGrid);
            var point = new Point { X = physicalPoint.Position.X, Y = physicalPoint.Position.Y };
            row = (Subject)(sender as RadDataGrid).HitTestService.RowItemFromPoint(point);
            var cell = (sender as RadDataGrid).HitTestService.CellInfoFromPoint(point);
        }

        private void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            EnrollSubjectDeleteDialog();
            //Mocks.Factory.SubjectManagerFactory.Mocking = false;
            //ISubjectManager subjectManager = Mocks.Factory.SubjectManagerFactory.GetSubjectManager();
            //ObservableCollection<SubjectWithGrade> collection = new ObservableCollection<SubjectWithGrade>(subjectManager.GetSubjectsWithGrades());
            //ObservableCollection<SubjectAndGrade> observable = SubjectService.GetTabbedPage(collection);
            //SubjectAndGrade temp = null;
            //foreach (var item in observable)
            //{
            //    if(item.Id == row.Id)
            //    {
            //        //Subjectből  -> SubjectAndGrade-t kell csinálni
            //        //temp = row;
            //    }
            //}
            //TODO temp Grade részét kell ide megadni
            //subjectManager.DeleteGradeOfSubject(temp);

            //Subject torlendo = null;

            //foreach (var item in ViewModel.SubjectSource)
            //{
            //    if(item.Id == row.Id)
            //    {
            //        torlendo = item;
            //    }
            //}

            ////TODO valahogy kiszedni az elemet és frissíteni a gridet
            //ViewModel.SubjectSource.Remove(torlendo);
            //EnrolledGrid.UpdateLayout();
            ////ViewModel.RaisePropertyChanged();
            ////EnrolledGrid.InvalidateArrange();
            ////EnrolledGrid.InvalidateMeasure();

        }

        private async void EnrollSubjectDeleteDialog()
        {
            ContentDialog enrollSubjectDialog = new ContentDialog
            {
                Title = "Biztosan törlöd ezt a tárgyat?",
                Content = string.Format("Tárgy név: {0} \nTárgykód: {1} \n" +
                                       "Kredit: {2} \nTárgyfelelős: {3} \n",
                                       row.Name, row.Code, row.Credit, row.ResponsibleProfessor),
                CloseButtonText = "Nem, mégse",
                PrimaryButtonText = "Igen, törlöm"
            };

            ContentDialogResult result = await enrollSubjectDialog.ShowAsync();

            if(result == ContentDialogResult.Primary)
            {
                ViewModel.subjectSource.Remove(row);
                EnrolledGrid.UpdateLayout();
            }
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    var parameters = e.Parameter as Subject;
        //    //int id = parameters.Id;
        //    //String name = parameters.Name;
        //    //String code = parameters.Code;
        //    //int credit = parameters.Credit;
        //    //int recommendedsemester = parameters.RecommendedSemester;
        //    //String responsibleprof = parameters.ResponsibleProfessor;

        //    bool unique = true;

        //    //Kell hogy 1 évbe csak egyszer lehessen felvenni 1 tárgyat
        //    /*foreach (var item in ViewModel.SubjectSource)
        //    {
        //        if(id == item.Id)
        //        {
        //            unique = false;
        //        }
        //    }*/

        //    if (unique == true) { ViewModel.subjectSource.Add(parameters); }
        //}
    }
}
