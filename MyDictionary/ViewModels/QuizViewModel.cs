using System;
using System.Collections.Generic;
using MvvmHelpers;
using System.Text;
using MvvmHelpers.Commands;
using MyDictionary.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyDictionary.Models;
using Xamarin.CommunityToolkit.Extensions;

namespace MyDictionary.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        string wordDefinition;
        string word1, word2, word3;
        bool switchEnglish = true;
        bool switchGeorgian = true;
        bool canClickButtons = true;
        Random rand = new Random();
        public string WordDefinition { get => wordDefinition; set => SetProperty(ref wordDefinition, value); }

        public string Word1 { get => word1; set => SetProperty(ref word1, value); }
        public string Word2 { get => word2; set => SetProperty(ref word2, value); }
        public string Word3 { get => word3; set => SetProperty(ref word3, value); }
        IWordService wordService;

        public bool SwitchEnglish 
        {
            get => switchEnglish;
            set 
            {
                SetProperty(ref switchEnglish, value);
            }
        }
        
        public bool SwitchGeorgian
        {
            get => switchGeorgian;
            set
            {
                SetProperty(ref switchGeorgian, value);
            }
        }

        List<Word> words;
        int correctWordIndex;
        public AsyncCommand<Button> CheckQuestionCommand { get; }
        public AsyncCommand GenerateQuestionCommand { get; }
        public AsyncCommand ToggledCommand { get; }
        public QuizViewModel()
        {
            Title = "Quiz";
            CheckQuestionCommand = new AsyncCommand<Button>(NewQuestion);
            GenerateQuestionCommand = new AsyncCommand(GenerateQuestion);
            ToggledCommand = new AsyncCommand(ToggledSwitch);
            wordService = DependencyService.Get<IWordService>();
        }

        async Task ToggledSwitch()
        {
            
            if (SwitchEnglish == false && SwitchGeorgian == false)
            {
                ClearButtonTxts();
                canClickButtons = false;
                await Shell.Current.DisplayToastAsync($"Quiz is disabled", 2000);
                
            }
            else
            {
                await GenerateQuestion();
            }
        }

        async Task NewQuestion(object clickedBtnObj)
        {
            if (canClickButtons)
            {
                canClickButtons = false;
                Button clickedBtn = clickedBtnObj as Button;
                var initialColor = clickedBtn.BackgroundColor;
                if (clickedBtn.Text == words[correctWordIndex].TheWord)
                {
                    clickedBtn.BackgroundColor = Color.LightGreen;
                }
                else
                {
                    clickedBtn.BackgroundColor = Color.Red;
                }
                await Task.Delay(1500);
                clickedBtn.BackgroundColor = initialColor;
                
                await GenerateQuestion();
            }

        }
        async Task GenerateQuestion()
        {
            if (switchEnglish == false)
            {
                words = await wordService.GetGeorgianWord();
                if (words.Count != 3)
                {
                    WordDefinition = "Quiz is unavailable. There are less than 3 words in Georgian dictionary";
                    ClearButtonTxts();
                    canClickButtons = false;
                    return;
                }
            }
            else if(switchGeorgian == false)
            {
                words = await wordService.GetEnglishWord();
                if (words.Count != 3)
                {
                    WordDefinition = "Quiz is unavailable. There are less than 3 words in English dictionary";
                    ClearButtonTxts();
                    canClickButtons = false;
                    return;
                }
            }
            else if(SwitchGeorgian == false && SwitchEnglish == false)
            {
                WordDefinition = "Quiz is unavailable. There are less than 3 words in one of the dictionaries";
                ClearButtonTxts();
                canClickButtons=false;
                return;
            }
            else
            {
                if (rand.Next(0, 2) == 1)
                {
                    words = await wordService.GetEnglishWord();
                    if(words.Count != 3)
                    {
                        WordDefinition = "Quiz is unavailable. There are less than 3 words in English dictionary";
                        ClearButtonTxts();
                        canClickButtons = false;
                        return;
                    }
                }
                else
                {
                    words = await wordService.GetGeorgianWord();
                    if (words.Count != 3)
                    {
                        WordDefinition = "Quiz is unavailable. There are less than 3 words in Georgian dictionary";
                        ClearButtonTxts();
                        canClickButtons = false;
                        return;
                    }
                }
                    
            }
            canClickButtons = true;
            correctWordIndex = rand.Next(0, 3);
            WordDefinition = words[correctWordIndex].Definition;

            Word1 = words[0].TheWord;
            Word2 = words[1].TheWord;
            Word3 = words[2].TheWord;
        }
        void ClearButtonTxts()
        {
            Word1 = " ";
            Word2 = " ";
            Word3 = " ";
        }
    }
}
