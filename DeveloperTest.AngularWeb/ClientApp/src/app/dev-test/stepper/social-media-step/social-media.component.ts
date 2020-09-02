import {Component, EventEmitter, OnChanges, Output, SimpleChanges} from '@angular/core';
import {ISocials} from "./ISocials";

@Component({
  selector: 'app-social-media',
  templateUrl: './social-media.component.html',
  styleUrls: ['./social-media.component.css']
})
export class SocialMediaComponent {
  socials: ISocials = {
    facebook: "",
    twitter: "",
    linkedIn: ""
  };

  @Output() data: EventEmitter<ISocials> = new EventEmitter<ISocials>();

  setSocial(social: string, event: Event) {
    this.socials[social] = event.target['value'];
    this.data.emit(this.socials);
  }
}
