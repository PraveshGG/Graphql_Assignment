using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using graphql_Assignment.Utils;
using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using graphql_Assignment.Models;
using System.Diagnostics;

namespace graphql_Assignment
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        //    List<Film> filmArrayList;
        List<Response> movieAList;
        public MainPage()
        {
            InitializeComponent();
        }
        private string API = Strings.url;

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            var client = new GraphQLClient(API);
            GraphQLRequest graphQLRequest = new GraphQLRequest
            {            
                //Query =  "query\n{\nallFilms\n{ \nfilms \n{ \n title,\n director \n}  \n} \n}"
                Query = "{\n       allFilms {\n         films {\n           title,\n          director\n             \n           }\n         }\n       }"
            };

            var httpResponse = await client.PostAsync(graphQLRequest);
            listViewFilms.ItemsSource = httpResponse.Data.allFilms.films.ToObject<List<Response>>();



            //Alternate Implementation
           /* AllFilms film = httpResponse.GetDataFieldAs<AllFilms>("allFilms");
             Debug.WriteLine("film size {0}", film.Films.Count);

              filmArrayList = new List<Film>(film.Films);
            check.Text = film.Films[0].Title;

             listViewFilms.ItemsSource = filmArrayList; */



        }

    }
}
