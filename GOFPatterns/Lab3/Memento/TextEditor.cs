namespace Lab2.Memento
{
    public class TextEditor
    {
        public string Text { get; set; } = string.Empty;

        public TextEditorMemento Save()
        {
            return new TextEditorMemento(Text);
        }

        public void Restore(TextEditorMemento memento)
        {
            if (memento == null)
            {
                return;
            }

            Text = memento.Text;
        }
    }
}