﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MindLedger.Domain;
using MindLedger.Domain.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MindLedger.AppLogic.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly INoteRepository _noteRepository;
    private readonly ITagRepository _tagRepository;

    public ObservableCollection<Campaign> Campaigns { get; } = new();
    public ObservableCollection<NoteBase> Notes { get; } = new();
    public ObservableCollection<Tag> AllTags { get; } = new();
    public ObservableCollection<Tag> SelectedTags { get; } = new();

    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private string content = string.Empty;

    [ObservableProperty]
    private Campaign? selectedCampaign;

    [ObservableProperty]
    private NoteBase? selectedNote;

    public MainWindowViewModel(INoteRepository noteRepository, ITagRepository tagRepository, ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
        _noteRepository = noteRepository;
        _tagRepository = tagRepository;
    }

    /// <summary>
    /// Asynchronously loads all campaigns from the repository and updates the collection.
    /// </summary>
    /// <remarks>This method clears the current collection of campaigns and populates it with the campaigns retrieved
    /// from the repository. It is intended to be used when refreshing or initializing the campaigns collection.</remarks>
    /// <returns>A task that represents the asynchronous operation</returns>
    [RelayCommand]
    public async Task LoadCampaignAsync()
    {
        Campaigns.Clear();
        var campaigns = await _campaignRepository.GetAllAsync();
        foreach (var c in campaigns)
            Campaigns.Add(c);
    }


    /// <summary>
    /// Asynchronously loads all notes from the repository and updates the collection.
    /// </summary>
    /// <remarks>This method clears the current collection of notes and populates it with the notes retrieved
    /// from the repository. It is intended to be used when refreshing or initializing the notes collection.</remarks>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [RelayCommand]
    public async Task LoadNotesAsync()
    {
        Notes.Clear();
        var notes = await _noteRepository.GetAllAsync();
        foreach (var note in notes)
            Notes.Add(note);
    }


    /// <summary>
    /// Adds a new note asynchronously to the repository and updates the local collection of notes.
    /// </summary>
    /// <remarks>This method creates a new note using the current values of <see cref="Title"/> and <see
    /// cref="Content"/>. If <see cref="Title"/> is null, empty, or consists only of whitespace, the method exits
    /// without performing any action. After successfully adding the note to the repository, the note is also added to
    /// the local <see cref="Notes"/> collection. The <see cref="Title"/> and <see cref="Content"/> properties are reset
    /// to empty strings upon completion.</remarks>
    /// <returns>A task representing the asynchronous operation.</returns>
    [RelayCommand]
    public async Task AddNoteAsync()
    {
        if (string.IsNullOrWhiteSpace(Title)) return;

        var note = new WorldNote
        {
            Title = Title,
            Content = Content
        };

        await _noteRepository.AddAsync(note);
        Notes.Add(note);

        Title = string.Empty;
        Content = string.Empty;

        note.Tags = SelectedTags.ToList();
    }


    /// <summary>
    /// Deletes the currently selected note asynchronously.
    /// </summary>
    /// <remarks>This method removes the selected note from the repository and the local collection of notes.
    /// If no note is selected, the method does nothing.</remarks>
    /// <returns>A task that represents the asynchronous delete operation.</returns>
    [RelayCommand]
    public async Task DeleteSelectedAsync()
    {
        if (SelectedNote is null) return;

        await _noteRepository.DeleteAsync(SelectedNote.Id);
        Notes.Remove(SelectedNote);
        SelectedNote = null;
    }


    [RelayCommand]
    public async Task LoadTagsAsync()
    {
        AllTags.Clear();
        var tags = await _tagRepository.GetAllAsync();
        foreach (var tag in tags)
            AllTags.Add(tag);
    }
}
