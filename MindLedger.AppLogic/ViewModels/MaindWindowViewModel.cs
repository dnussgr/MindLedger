using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MindLedger.Domain;
using MindLedger.Domain.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MindLedger.AppLogic.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INoteRepository _noteRepository;

    public ObservableCollection<NoteBase> Notes { get; } = new();

    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private string content = string.Empty;

    [ObservableProperty]
    private NoteBase? selectedNote;

    public MainWindowViewModel(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [RelayCommand]
    public async Task LoadNotesAsync()
    {
        Notes.Clear();
        var notes = await _noteRepository.GetAllAsync();
        foreach (var note in notes)
            Notes.Add(note);
    }

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
    }

    [RelayCommand]
    public async Task DeleteSelectedAsync()
    {
        if (SelectedNote is null) return;

        await _noteRepository.DeleteAsync(SelectedNote.Id);
        Notes.Remove(SelectedNote);
        SelectedNote = null;
    }
}
