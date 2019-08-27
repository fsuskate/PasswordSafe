namespace Security
{
    public class NaiveEncryption
    { 
       public static string Encrypt(string input, int rotateBy)
        {
            if (rotateBy < 0 || rotateBy > 9)
            {
                throw new System.Exception("Invalid rotate by number!");                    
            }

            var output = new System.Text.StringBuilder();
            // rotate string by 1
            for (var i = 0; i < input.Length; i++)
            {
                // rotate the char
                int c = (int)input[i];
                c += rotateBy;
                output.Append((char)c);
            }
            var result = output.ToString();
            result += rotateBy.ToString();
            return result;
        }

        public static string Decrypt(string input)
        {
            input = input.Trim('"');
            int rotateBy = int.Parse(input[input.Length - 1].ToString());
            if (rotateBy < 0 || rotateBy > 9)
            {
                throw new System.Exception("Invalid rotate by number!");
            }

            input = input.Substring(0, input.Length - 1);
            var decrypted = new System.Text.StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                // rotate the char
                int c = (int)input[i];
                c -= rotateBy;
                decrypted.Append((char)c);
            }
            return decrypted.ToString();
        }
    }
}
