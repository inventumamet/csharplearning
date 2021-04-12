namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override Statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }
    }
}