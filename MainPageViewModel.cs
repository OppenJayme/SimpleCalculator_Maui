using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calculator1;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string expressionDisplay = string.Empty;

    [ObservableProperty]
    private string resultDisplay = string.Empty;

    private bool isNewInput = false;
    [RelayCommand]
    public void HandleButtonPress(string buttonText)
    {
        if (buttonText == "AC")
        {
            ExpressionDisplay = string.Empty;
            ResultDisplay = string.Empty;
            return;
        }

        if (buttonText == "DE")
        {
            if (!string.IsNullOrEmpty(ExpressionDisplay))
                ExpressionDisplay = ExpressionDisplay[..^1];
            return;
        }

        if (buttonText == "=")
        {
            try
            {
                var result = new DataTable().Compute(ExpressionDisplay.Replace("X", "*"), null);
                ResultDisplay = result.ToString();
                ExpressionDisplay = ResultDisplay;
            }
            catch
            {
                ResultDisplay = "Error";
            }
            return;
        }

        if (isNewInput && "+-X/".Contains(buttonText))
        {
            isNewInput = false;
        }
        else if (isNewInput)
        {
            ExpressionDisplay = string.Empty;
            isNewInput = false;
        }

        ExpressionDisplay += buttonText;
    }
}

