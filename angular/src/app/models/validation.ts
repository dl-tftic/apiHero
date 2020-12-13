import { FormGroup, ValidationErrors, ValidatorFn } from '@angular/forms';

export const confirmPasswordValidator: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
    const pwd = control.get('Password').value;
    const confirm = control.get('ConfirmPassword').value;
    if (control.get('ConfirmPassword').dirty || control.get('ConfirmPassword').touched)
    {
        return pwd === confirm ? null : {showError : true};
    }
    return null;
};

export class Validation {
}
