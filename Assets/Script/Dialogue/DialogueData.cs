using System;
using System.Collections.Generic;

[Serializable]
public class DialogueLine
{
    public string speaker;
    public string text;
}

[Serializable]
public class DialogueContainer
{
    public List<DialogueLine> lines;
}
