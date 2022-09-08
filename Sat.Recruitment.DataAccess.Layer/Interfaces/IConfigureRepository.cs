namespace Sat.Recruitment.DataAccess.Repositories
{
    public  interface IConfigureRepository
    {
        void initModel(int countRecordToAdd = 0);
    }
}