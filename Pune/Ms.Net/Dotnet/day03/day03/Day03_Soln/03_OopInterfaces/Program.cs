namespace _03_OopInterfaces
{
    // Editor with multiple spell checkers
    interface ISpellChecker
    {
        void SpellCheck(string word);
    }
    class EnglishSpellChecker : ISpellChecker
    {
        // ...
        public void SpellCheck(string word)
        {
            Console.WriteLine("English Spell Check: " + word);
        }
    }
    class FrenchSpellChecker : ISpellChecker
    {
        public void SpellCheck(string word)
        {
            Console.WriteLine("French Spell Check: " + word);
        }
    }
    class SpanishSpellChecker : ISpellChecker
    {
        public void SpellCheck(string word)
        {
            Console.WriteLine("Spanish Spell Check: " + word);
        }
    }
    class Editor
    {
        // fields -- data
        // methods -- Save(), Open(), Validate(), ...
        private ISpellChecker _spellChecker;
        public Editor()
        {
            _spellChecker = new EnglishSpellChecker();
        }
        public Editor(ISpellChecker spellChecker)
        {
            _spellChecker = spellChecker;
        }
        public void Validate()
        {
            //foreach word in data
            _spellChecker.SpellCheck("word");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1. English\n2. French\n3. Spanish\nEnter option: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            ISpellChecker spellChecker = null;
            switch (choice)
            {
                case 1:
                    spellChecker = new EnglishSpellChecker();
                    break;
                case 2:
                    spellChecker = new FrenchSpellChecker();
                    break;
                case 3:
                    spellChecker = new SpanishSpellChecker();
                    break;
            }
            Editor editor = new Editor(spellChecker);
            //editor.Open();
            editor.Validate();
            //editor.Save();
        }
    }
}
