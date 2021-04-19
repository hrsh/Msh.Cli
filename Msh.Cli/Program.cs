using System;
using McMaster.Extensions.CommandLineUtils;

var app = new CommandLineApplication();
app.Command("docker", a =>
{
    a.HelpOption();
    var image = a.Option("-i|--image <IMAGE>", "The image", CommandOptionType.SingleValue);
    var tag = a.Option("-t|--tag", "The image tag", CommandOptionType.SingleValue);
    var b = a.Argument("image", "the image");
    tag.IsRequired();
    a.OnExecute(() =>
    {

        Console.WriteLine(image.Value() + "@" + b.Value + ":" + tag.Value());
    });
});
app.HelpOption();
var subject = app.Option("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);
subject.ShowInHelpText = true;

var repeat = app.Option<int?>("-n|--count <N>", "Repeat", CommandOptionType.SingleValue);
repeat.DefaultValue = 1;



app.OnExecute(() =>
{
    for (var i = 0; i < repeat.ParsedValue; i++)
    {
        Console.WriteLine($"Hello {subject.Value()}!");
    }
});

return app.Execute(args);

//Import-Module "D:\MyProgramming\Demoes\msh-cli\Msh.Cli\Msh.Cli\bin\Debug\net5.0\mazdak.dll"