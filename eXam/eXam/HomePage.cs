using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace eXam
{
    public class HomePage : ContentPage
    {

        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            AbsoluteLayout absoluteLayout = new AbsoluteLayout();

            this.Content = absoluteLayout;

            Image image = new Image
            {
                Source = ImageSource.FromResource("eXam.Images.background.jpg"),
                Aspect = Aspect.AspectFill
            };

            absoluteLayout.Children.Add(
                view: image,
                bounds: new Rectangle(0,0,1,1),
                flags: AbsoluteLayoutFlags.SizeProportional);

            Button button = new Button
            {
                Text = "Start eXam",
                BackgroundColor = Color.LightCoral,
                Font = Font.SystemFontOfSize(20)
            };

            button.Clicked += async (sender, args) =>
            {
                var viewModel = new QuestionPageViewModel(App.CurrentGame);
                await this.Navigation.PushAsync(new QuestionPage(viewModel));
            };

            absoluteLayout.Children.Add(
                view: button,
                bounds: new Rectangle(x: 0.5, y: 0.5, width: 150, height: 60),
                flags: AbsoluteLayoutFlags.PositionProportional);
        }
    }
}