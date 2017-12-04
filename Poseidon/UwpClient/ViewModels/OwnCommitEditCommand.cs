using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Grid.Commands;
using UwpClient.Models;
using UwpClient.Services;

namespace UwpClient.ViewModels
{
    public class OwnCommitEditCommand : DataGridCommand
    {
        public OwnCommitEditCommand()
        {
            this.Id = CommandId.CommitEdit;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var context = parameter as EditContext;
            var cellinfo = context.CellInfo;
            var item =  (SubjectAndGrade)cellinfo.Item;

            if(item.ReceivedGrade >= 1 && item.ReceivedGrade <= 5)
            {
                Grade grade = new Grade(item.StudentID,item.SubjectID,item.EnrollmentSemester,item.Signature,item.Passed,item.ReceivedGrade);
                SubjectService.UpdateGradeToDatabase(grade);
            }
            
            // Executes the default implementation of this command
            this.Owner.CommandService.ExecuteDefaultCommand(CommandId.CommitEdit, context);
        }
    }
}
