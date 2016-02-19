namespace Erpi.UnitTest.Demo.Refactored.Verifier
{
    // The waiter should be happy about whatever he/she can get if there is any. 
    // "Beg, people!" says Stowie.
    public class MinTipVerifier : ITipVerifier
    {
        public bool Verify(decimal amount)
        {
            return amount > 0;
        }
    }
}
