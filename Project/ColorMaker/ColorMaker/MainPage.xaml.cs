using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorMaker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]


    public partial class MainPage : ContentPage
    {
        //Nul aanmaken
        string nul = 0.ToString();

        //Aanmaken KLEUR
        Color kleur = new Color();

        public MainPage()
        {
            InitializeComponent();
        }

        //SCHERM LADEN
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            SetToBlack();
            SetToNul();

            ediOutput.Text = "#000000";

            InputVisibility(true);
            RandomVisibility(false);

            cbColorInput.IsToggled = true;
        }



        //--- INPUT GEDEELTE ---\\
        private void cbColorInput_Toggled(object sender, ToggledEventArgs e)
        {
            if (cbColorInput.IsToggled == true)
            {
                InputVisibility(true);

                cbColorInput.IsToggled = true;
                cbColorRandom.IsToggled = false;
            }
            else
            {
                InputVisibility(false);

                cbColorInput.IsToggled = false;
                cbColorRandom.IsToggled = true;
            }

            SetToBlack();
        }

        //RESET Buttons
        private void btnResetRodeButton_Clicked(object sender, EventArgs e)
        {
            entRood.Text = nul;
            sldRood.Value = int.Parse(nul);
        }

        private void btnResetGroeneButton_Clicked(object sender, EventArgs e)
        {
            entGroen.Text = nul;
            sldGroen.Value = int.Parse(nul);
        }

        private void btnResetBlauweButton_Clicked(object sender, EventArgs e)
        {
            entBlauw.Text = nul;
            sldBlauw.Value = int.Parse(nul);
        }

        //SLIDERS veranderen
        private void sldRood_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void sldGroen_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void sldBlauw_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        //TEXT bij input veranderd
        private void entRood_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void entGroen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void entBlauw_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //BUTTON input kleur initialiseren
        private void btnPassColorCode_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entRood.Text))
            {
                entRood.Text = nul;
            }
            if (string.IsNullOrWhiteSpace(entGroen.Text))
            {
                entGroen.Text = nul;
            }
            if (string.IsNullOrWhiteSpace(entBlauw.Text))
            {
                entBlauw.Text = nul;
            }
            else
            {
                entRood.Text = ColorSetter(int.Parse(entRood.Text)).ToString();
                entGroen.Text = ColorSetter(int.Parse(entGroen.Text)).ToString();
                entBlauw.Text = ColorSetter(int.Parse(entBlauw.Text)).ToString();
            }

            string kleurHex = HexMaker(entRood.Text, entGroen.Text, entBlauw.Text);
            ediOutput.Text = kleurHex;

            kleur = ByteSwitcher(entRood.Text, entGroen.Text, entBlauw.Text);
            lblColorLabel.BackgroundColor = kleur;
        }



        //--- RANDOM GEDEELTE ---\\
        private void cbColorRandom_Toggled(object sender, ToggledEventArgs e)
        {
            if (cbColorRandom.IsToggled == true)
            {
                RandomVisibility(true);

                cbColorRandom.IsToggled = true;
                cbColorInput.IsToggled = false;
            }
            else
            {
                RandomVisibility(false);

                cbColorRandom.IsToggled = false;
                cbColorInput.IsToggled = true;
            }

            SetToBlack();
        }

        //BUTTON Random kleur initialiseren
        private void btnPassRandomCode_Clicked(object sender, EventArgs e)
        {
            Random willekeurig = new Random();

            int rood = willekeurig.Next(0, 255);
            int groen = willekeurig.Next(0, 255);
            int blauw = willekeurig.Next(0, 255);

            entRoodRandom.Text = rood.ToString();
            entGroenRandom.Text = groen.ToString();
            entBlauwRandom.Text = blauw.ToString();

            ediOutput.Text = HexMaker(rood.ToString(), groen.ToString(), blauw.ToString());

            kleur = ByteSwitcher(rood.ToString(), groen.ToString(), blauw.ToString());
            lblColorLabel.BackgroundColor = kleur;
        }



        //--- RESET KLEURCODE bij output ---\\
        private void btnResetColorCode_Clicked(object sender, EventArgs e)
        {
            ediOutput.Text = "#000000";

            SetToBlack();
        }



        //--- METHODES ---\\

        //KLEUR setter
        private int ColorSetter(int kleur)
        {
            if (kleur < 0)
            {
                kleur = 0;
            }
            if (kleur > 255)
            {
                kleur = 255;
            }

            return kleur;
        }

        //HEX berekening
        private string HexMaker(string textR, string textG, string textB)
        {
            int rood = int.Parse(textR);
            int groen = int.Parse(textG);
            int blauw = int.Parse(textB);

            string hex = $"#{rood.ToString("X2")}{groen.ToString("X2")}{blauw.ToString("X2")}";

            return hex;
        }

        //BYTE bewerking
        private Color ByteSwitcher(string textR, string textG, string textB)
        {
            byte roodByte = byte.Parse(textR);
            byte groenByte = byte.Parse(textG);
            byte blauwByte = byte.Parse(textB);

            Color kleur = Color.FromRgb(roodByte, groenByte, blauwByte);

            return kleur;
        }

        //RESET scherm naar zwart
        private void SetToBlack()
        {
            Color klr = Color.FromRgb(0, 0, 0);
            lblColorLabel.BackgroundColor = klr;
        }

        //Schermen op nul (0) zetten
        private void SetToNul()
        {
            entRood.Text = nul;
            entGroen.Text = nul;
            entBlauw.Text = nul;
            entRoodRandom.Text = nul;
            entGroenRandom.Text = nul;
            entBlauwRandom.Text = nul;
        }

        //Visibility INPUT (hidden / visible)
        private void InputVisibility(bool veld)
        {
            entRood.IsVisible = veld;
            entGroen.IsVisible = veld;
            entBlauw.IsVisible = veld;
            btnPassColorCode.IsVisible = veld;
            btnResetRodeButton.IsVisible = veld;
            btnResetGroeneButton.IsVisible = veld;
            btnResetBlauweButton.IsVisible = veld;
            lblRoodInput.IsVisible = veld;
            lblGroenInput.IsVisible = veld;
            lblBlauwInput.IsVisible = veld;
            sldRood.IsVisible = veld;
            sldGroen.IsVisible = veld;
            sldBlauw.IsVisible = veld;

            SetToNul();
        }

        //Visibility RANDOM (hidden / visible)
        private void RandomVisibility(bool veld)
        {
            entRoodRandom.IsVisible = veld;
            entGroenRandom.IsVisible = veld;
            entBlauwRandom.IsVisible = veld;
            btnPassRandomCode.IsVisible = veld;
            lblRoodRandom.IsVisible = veld;
            lblGroenRandom.IsVisible = veld;
            lblBlauwRandom.IsVisible = veld;

            SetToNul();
        }
    }
}
