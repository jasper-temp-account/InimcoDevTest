import {Component} from '@angular/core';
import {StepperSelectionEvent} from "@angular/cdk/stepper";
import {HttpService} from "./HttpService";
import {PersonData} from "./PersonData";
import {ISocials} from "./social-media-step/ISocials";
import {MatHorizontalStepper} from "@angular/material/stepper";

@Component({
  selector: 'app-dev-test-stepper',
  templateUrl: './dev-test-stepper.component.html',
  styleUrls: ['./dev-test-stepper.component.css']
})
export class DevTestStepperComponent {
  personData: PersonData = {
    name: "",
    socialSkills: [],
    socialMediaAccounts: undefined
  };

  amountOfVowels: number;
  amountOfConsonants: number;
  reversedName: string;

  constructor(private _httpService: HttpService) {

  }

  selectionChanged(event: StepperSelectionEvent) {
    if(event.selectedIndex === 3) {
      this._httpService.reverseName(this.personData.name).subscribe(reversedName => this.reversedName = reversedName);
      this._httpService.vowelCount(this.personData.name).subscribe(count => this.amountOfVowels = +count);
      this._httpService.consonantCount(this.personData.name).subscribe(count => this.amountOfConsonants = +count);
    }
  }

  socialSkillsChanged(socialSkills: string[]) {
    this.personData.socialSkills = socialSkills;
  }

  socialMediaChanged(socialMedia: ISocials) {
    this.personData.socialMediaAccounts = socialMedia;
  }

  stepperNextIfNotUndefined(stepper: MatHorizontalStepper) {
    if (this.personData.name)
      stepper.next();
    else
      alert('Please enter your full name');
  }
}
