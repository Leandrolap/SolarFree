﻿using SolarFree.View;

namespace SolarFree;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new Login();

        //MainPage = new NavigationPage(new Login());
    }
}
