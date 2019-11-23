namespace TextAnalyzer
{
    public class LetterOccurrenceModel
    {
        public char letter { get; set; }
        public int count { get; set; }


        public LetterOccurrenceModel(char letter, int count = 0)
        {
            this.letter = letter;
            this.count = count;
        }

        public void Increase()
        {
            this.count++;
        }
    }
}