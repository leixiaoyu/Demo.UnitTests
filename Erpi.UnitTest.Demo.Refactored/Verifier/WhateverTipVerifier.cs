namespace Erpi.UnitTest.Demo.Refactored.Verifier
{
    // The waiter should be happy no matter what. 
    public class WhateverTipVerifier : ITipVerifier
    {
        public bool Verify(decimal amount)
        {
            return true;
        }
    }
}
