using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_Example
{
    public interface IControler
    {
        void ShowMenu();

        int UserChoice();

        string ChooseRecord();

        void PrintRecord(Car car);

        Dictionary<string, string> RecordToCreateInformation();

        Dictionary<string, string> RecordToUpdateInformation(Car car);

        void DelatedRecordInfo(Car car);

        void DisplayError(string massage, int miliseconds);

        void NoRecordInDatabaseInfo();
    }
}
