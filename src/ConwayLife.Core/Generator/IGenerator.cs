namespace ConwayLife.Core
{
    public interface IGenerator<TField>
        where TField : new()
    {
        Map<TField> map { get; set; }
        void NextGeneration();
        void PrevGeneration();

        void Reset();
        bool IsNothingChanges();
    }
}