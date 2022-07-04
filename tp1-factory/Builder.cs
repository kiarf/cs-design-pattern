using System;

public abstract class Liasse
{
    protected IList<string> contenu = new List<string>();
    public abstract void ajouteDocument(string document);
    public abstract void imprime();
}

public class LiasseHtml : Liasse
{
    public override void ajouteDocument(string document)
    {
        if (document.StartsWith("<HTML>"))
            contenu.Add(document);
    }

    public override void imprime()
    {
        if (document.StartsWith("<HTML>"))
            contenu.Add(document);
    }

}