using AutomatedTellerMachine.Services;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTellerMachine.Models
{
    public class WithdrawalService : IWithdrawal
    {
        public Response Dispensor(int amount)
        {
            StringBuilder sb = new StringBuilder();
            int[] denominators = { 1000, 500, 200, 100, 50, 20, 10 };
            Response response = new Response();
            try
            {
                if (amount % 10 == 0)
                {
                    for (int i = 0; i < denominators.Length; i++)
                    {
                        string st = DispensorHelper(amount, i);
                        if (!st.Equals(string.Empty))
                        {
                            st = st.Substring(0, st.LastIndexOf("+")); // Remove the last + resulted by the last call of the recursive function
                            sb.Append("<input type=\"radio\" name=\"dispense\" value=\"" + i + "\"> " + st + "<br>");
                        }

                    }
                    response.Status = true;
                    response.Message = sb.ToString();
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

        public string DispensorHelper(int amount, int index)
        {
            int[] denominators = { 1000, 500, 200, 100, 50, 20, 10, 1 };
            if (amount / denominators[index] < 1)
                return string.Empty;
            else
            {
                int count = amount / denominators[index];

                return Convert.ToString(count) + "*" + Convert.ToString(denominators[index]) + "+" + DispensorHelper(amount - (count * denominators[index]), ++index);
            }
        }

        public Task<bool> Withdraw(int amount)
        {
            throw new NotImplementedException();
        }

    }
}