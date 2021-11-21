namespace TreasuryChallenge
{
    class Start
    {
        static async Task Main(string[] args)
        {
            await Service.WriteCodes();
        }
    }
}