using ShelfLayoutManager.Core.Services;

namespace ShelfLayoutManager.Infrastructure.Services
{
    public class JanCodeValidatorService : IJanCodeValidatorService
    {
        public bool IsValidJanCode(string janCode)
        {
            if (string.IsNullOrWhiteSpace(janCode) || (janCode.Length != 8 && janCode.Length != 13))
                return false;

            try
            {
                return CheckJanCode(janCode);
            }
            catch
            {
                // If there is an error in the process (for example, if the code contains non-numeric characters)
                return false;
            }
        }

        private bool CheckJanCode(string janCode)
        {
            int sum = 0;
            for (int i = 0; i < janCode.Length - 1; i++)
            {
                if (int.TryParse(janCode[i].ToString(), out int digit))
                {
                    // Se a posição for par (da direita para a esquerda), soma o dígito;
                    // se for ímpar, soma o triplo do dígito.
                    // Nota: i % 2 == 0 é verdadeiro para posições ímpares na contagem da direita para a esquerda
                    sum += (i % 2 == 0) ? digit * 3 : digit;
                }
                else
                {
                    throw new InvalidOperationException("The JAN code contains non-numeric characters.");
                }
            }

            int modulo = sum % 10;
            int checkDigit = (modulo == 0) ? 0 : 10 - modulo;

            // Comparar o dígito de verificação calculado com o último dígito do JAN Code
            var result = checkDigit == int.Parse(janCode[janCode.Length - 1].ToString());
            return result;
        }

    }
}