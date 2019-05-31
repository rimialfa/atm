using AutomatedTellerMachine.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AutomatedTellerMachine.Models
{
    public class WithdrawalService : IWithdrawal
    {
        private static readonly int[] denominators = { 200, 100, 50, 20, 10, 1 };
        private IAccount _service;

        public WithdrawalService()
        {
            _service = new AccountService();
        }

        public WithdrawalService(IAccount account)
        {
            _service = account;
        }
        public Response Denominator(int amount)
        {
            //StringBuilder sb = new StringBuilder();
            List<RadioListViewModel> rl = new List<RadioListViewModel>();

            Response response = new Response();
            try
            {
                if (amount % 10 == 0)
                {
                    for (int i = 0; i < denominators.Length; i++)
                    {
                        if (denominators[i] != 1)
                        {
                            string st = DenominatorHelper(amount, i);
                            if (!st.Equals(string.Empty))
                            {
                                st = st.Substring(0, st.LastIndexOf("+")); // Remove the last + resulted by the last call of the recursive function
                                rl.Add(new RadioListViewModel { Label = st, Value = i });
                            }
                        }

                    }
                    response.Status = true;
                    response.Message = JsonConvert.SerializeObject(rl);
                }
                else
                {
                    response.Status = false;
                    response.Message = "Amount must be evenly divisible by 10 with no cents";
                }

            }
            catch (Exception e)
            {
                response.Status = false;
                response.Message = e.ToString();
            }

            return response;
        }

        public string DenominatorHelper(int amount, int index)
        {
            if (amount / denominators[index] < 1)
                return string.Empty;
            else
            {
                int count = amount / denominators[index];

                return Convert.ToString(count) + "*" + Convert.ToString(denominators[index]) + "+" + DenominatorHelper(amount - (count * denominators[index]), ++index);
            }
        }

        public Response Dispensor(int amount)
        {
            Response response = new Response();
            if (_service.UpdateBalance((-1 * amount)).Status)
            {
                response.Status = true;
            }
            return response;
        }
    }
}