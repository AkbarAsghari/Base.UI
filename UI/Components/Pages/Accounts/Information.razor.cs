using Microsoft.AspNetCore.Components;
using UI.Interfaces.Repositories;

namespace UI.Components.Pages.Accounts;

partial class Information
{
    [Inject] IAccountRepository _AccountRepository { get; set; }
    [Inject] ISnackbar _Snackbar { get; set; }

    UserDTO? _CurrentUser = new();
    protected override async Task OnInitializedAsync()
    {
        _CurrentUser = await _AccountRepository.GetCurrentUserAsync();
    }


    bool _EditMobileDialogVisible = false;
    void EditMobile()
    {
        _EditMobileDialogVisible = true;
    }



    bool _EditPasswordDialogVisible = false;
    void EditPassword()
    {
        _EditPasswordDialogVisible = true;
    }
    MudForm _ChangePasswordForm;
    ChangePasswordDTO _ChangePasswordDTO = new();
    async Task SaveNewPassword()
    {
        await _ChangePasswordForm.Validate();
        if (_ChangePasswordForm.IsValid)
        {
            if (await _AccountRepository.ChangePasswordAsync(_ChangePasswordDTO))
            {
                _ChangePasswordDTO = new();
                _EditPasswordDialogVisible = false;
                _Snackbar.Add("رمز عبور شما با موفقیت تغییر یافت", Severity.Success);
            }
        }
    }

    bool _EditEmailDialogVisible = false;
    void EditEmail()
    {
        _NewEmailAddress = _CurrentUser!.Email;
        _EditEmailDialogVisible = true;
    }
    MudForm _EditEmailForm;
    string _NewEmailAddress;
    async Task SaveNewEmail()
    {
        await _EditEmailForm.Validate();
        if (_EditEmailForm.IsValid)
        {
            if (_NewEmailAddress.Equals(_CurrentUser!.Email))
            {
                _NewEmailAddress = String.Empty;
                _EditEmailDialogVisible = false;
                return;
            }

            if (await _AccountRepository.ChangeEmailAsync(_NewEmailAddress))
            {
                _CurrentUser!.Email = _NewEmailAddress;
                _NewEmailAddress = String.Empty;
                _EditEmailDialogVisible = false;
                _Snackbar.Add("ایمیل شما با موفقیت تغییر یافت . کد تایید به ایمیل شما ارسال شد", Severity.Success);
            }
        }
    }

    bool _EditUsernameDialogVisible = false;
    void EditUsername()
    {
        _NewUsername = _CurrentUser!.Username;
        _EditUsernameDialogVisible = true;
    }
    string? _NewUsername;
    async Task SaveNewUsername()
    {
        if (_NewUsername!.Equals(_CurrentUser!.Username))
        {
            _NewEmailAddress = String.Empty;
            _EditEmailDialogVisible = false;
            return;
        }

        if (await _AccountRepository.UpdateUsernameAsync(_NewUsername))
        {
            _CurrentUser!.Username = _NewUsername;
            _NewUsername = String.Empty;
            _EditUsernameDialogVisible = false;
            if (String.IsNullOrEmpty(_CurrentUser!.Username))
            {
                _Snackbar.Add($"نام کاربری شما با موفقیت خذف شد و از این پس باید با آدرس ایمیل {_CurrentUser!.Email} وارد شوید", Severity.Success);
            }
            else
            {
                _Snackbar.Add($"نام کاربری شما با موفقیت به  {_CurrentUser!.Username} تغییر یافت شما میتوانید از این پس با این نام کاربری نیز وارد شوید", Severity.Success);
            }
        }
    }
}
