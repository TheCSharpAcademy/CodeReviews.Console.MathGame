using Math_Game.Enums;
using Math_Game.Tools;
using System;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("MathGameTests")]

namespace Math_Game.Application;

internal class QuestionGenerator
{
    IRandom _random;
    public QuestionGenerator(IRandom random)
    {
        _random = random;
    }

    public Question Generate(Difficulty difficulty, MenuOptions questionType)
    {
        return (difficulty, questionType) switch
        {
            (Difficulty.Easy, MenuOptions.Sum) => QuestionsRepository.EasyQuestionsSum
                .ElementAt(_random
                .Next(QuestionsRepository.EasyQuestionsSum.Count())),
            (Difficulty.Easy, MenuOptions.Subtraction) => QuestionsRepository.EasyQuestionsSubtraction
                .ElementAt(_random
                .Next(QuestionsRepository.EasyQuestionsSubtraction.Count())),
            (Difficulty.Easy, MenuOptions.Multiplication) => QuestionsRepository.EasyQuestionsMultiplication
                .ElementAt(_random
                .Next(QuestionsRepository.EasyQuestionsMultiplication.Count())),
            (Difficulty.Easy, MenuOptions.Division) => QuestionsRepository.EasyQuestionsDivision
                .ElementAt(_random
                .Next(QuestionsRepository.EasyQuestionsDivision.Count())),
            (Difficulty.Medium, MenuOptions.Sum) => QuestionsRepository.MediumQuestionsSum
                .ElementAt(_random
                .Next(QuestionsRepository.MediumQuestionsSum.Count())),
            (Difficulty.Medium, MenuOptions.Subtraction) => QuestionsRepository.MediumQuestionsSubtraction
                .ElementAt(_random
                .Next(QuestionsRepository.MediumQuestionsSubtraction.Count())),
            (Difficulty.Medium, MenuOptions.Multiplication) => QuestionsRepository.MediumQuestionsMultiplication
                .ElementAt(_random
                .Next(QuestionsRepository.MediumQuestionsMultiplication.Count())),
            (Difficulty.Medium, MenuOptions.Division) => QuestionsRepository.MediumQuestionsDivision
                .ElementAt(_random
                .Next(QuestionsRepository.MediumQuestionsDivision.Count())),
            (Difficulty.Hard, MenuOptions.Sum) => QuestionsRepository.HardQuestionsSum
                .ElementAt(_random
                .Next(QuestionsRepository.HardQuestionsSum.Count())),
            (Difficulty.Hard, MenuOptions.Subtraction) => QuestionsRepository.HardQuestionsSubtraction
                .ElementAt(_random
                .Next(QuestionsRepository.HardQuestionsSubtraction.Count())),
            (Difficulty.Hard, MenuOptions.Multiplication) => QuestionsRepository.HardQuestionsMultiplication
                .ElementAt(_random
                .Next(QuestionsRepository.HardQuestionsMultiplication.Count())),
            (Difficulty.Hard, MenuOptions.Division) => QuestionsRepository.HardQuestionsDivision
                .ElementAt(_random
                .Next(QuestionsRepository.HardQuestionsDivision.Count())),
            (Difficulty.Random, MenuOptions.Sum) => QuestionsRepository.RandomDifficultySumQuestions()
                .ElementAt(_random
                .Next(QuestionsRepository.RandomDifficultySumQuestions().Count())),
            (Difficulty.Random, MenuOptions.Subtraction) => QuestionsRepository.RandomDifficultySubtractionQuestions()
                .ElementAt(_random
                .Next(QuestionsRepository.RandomDifficultySubtractionQuestions().Count())),
            (Difficulty.Random, MenuOptions.Multiplication) => QuestionsRepository.RandomDifficultyMultiplicationQuestions()
                .ElementAt(_random
                .Next(QuestionsRepository.RandomDifficultyMultiplicationQuestions().Count())),
            (Difficulty.Random, MenuOptions.Division) => QuestionsRepository.RandomDifficultyDivisionQuestions()
                .ElementAt(_random
                .Next(QuestionsRepository.RandomDifficultyDivisionQuestions().Count())),
            (Difficulty.Easy, MenuOptions.Mixed) => QuestionsRepository.EasyDifficultyMixedQuestions()
                .ElementAt(_random
                .Next(QuestionsRepository.EasyDifficultyMixedQuestions().Count())),
            (Difficulty.Medium, MenuOptions.Mixed) => QuestionsRepository.MediumDifficultyMixedQuestions()
                .ElementAt(_random
                .Next(QuestionsRepository.MediumDifficultyMixedQuestions().Count())),
            (Difficulty.Hard, MenuOptions.Mixed) => QuestionsRepository.HardDifficultyMixedQuestions()
                .ElementAt(_random
                .Next(QuestionsRepository.HardDifficultyMixedQuestions().Count())),
            (Difficulty.Random, MenuOptions.Mixed) => QuestionsRepository.RandomDifficultyMixedQuestions()
            .ElementAt(_random
            .Next(QuestionsRepository.RandomDifficultyMixedQuestions().Count())),

        };
    }
}