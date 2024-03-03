    /*
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        if(w.Length == 1)
            return "no answer";
        
        char[] characters = w.ToCharArray();
        int endIndex = 0;
        
        for( endIndex = w.Length - 1; endIndex > 0; endIndex--)
            if(w[endIndex] > w[endIndex - 1])
                break;
        
        if(endIndex == 0)
            return "no answer";
        else
        {
            int firstSmallCharacterAt = characters[endIndex - 1];
            int nextSmallCharacterAt = endIndex;
            
            for(int i = endIndex + 1; i < characters.Length; i++)
                if(characters[i] > firstSmallCharacterAt 
                && characters[i] < characters[nextSmallCharacterAt])
                nextSmallCharacterAt = i;
            
            Swap(characters, endIndex - 1, nextSmallCharacterAt);
            Array.Sort(characters, endIndex, characters.Length - endIndex);
        }   
        return new string(characters);
    }
    
    public static void Swap(char[] characters, int i, int j)
    {
        char temp = characters[i];
        characters[i] = characters[j];
        characters[j] = temp;        
    }
