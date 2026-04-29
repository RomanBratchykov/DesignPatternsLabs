using System.Collections.Generic;

namespace Lab2.Memento
{
    public class TextEditorHistory
    {
        private readonly Stack<TextEditorMemento> _history = new Stack<TextEditorMemento>();

        public void Save(TextEditor editor)
        {
            if (editor == null)
            {
                return;
            }

            _history.Push(editor.Save());
        }

        public void Undo(TextEditor editor)
        {
            if (editor == null || _history.Count == 0)
            {
                return;
            }

            editor.Restore(_history.Pop());
        }
    }
}