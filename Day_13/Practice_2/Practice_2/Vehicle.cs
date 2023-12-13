namespace Practice_2
{
    public abstract class Vehicle
    {
        protected abstract string OriginCountry { get; set; }
        protected abstract string GetOriginCountry();
        protected abstract string ChooseType();
        protected abstract void PrintInfo();
        protected abstract void PrintFinalResult();
    }
}