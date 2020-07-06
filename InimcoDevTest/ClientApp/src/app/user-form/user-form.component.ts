import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from './models/user';
import { UserService } from './service/user.service';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import { UserObjectResult } from './models/user-object-result';
import { MessageService } from 'primeng/api';
import { SocialAccount } from './models/social-account';

@Component({
    selector: 'user-form',
    templateUrl: './user-form.component.html',
    styleUrls: ['./user-form.component.css']
})


export class UserFormComponent implements OnInit {

    
    displayDialog: boolean = false;
    userForm: FormGroup;
    userObjectResult: UserObjectResult;
    @ViewChild('ngFormUser', {static: false}) ngFormUser: NgForm;

    constructor(private userService: UserService, 
        private messageService: MessageService,
        ){}

    
  ngOnInit(): void {
        this.initFormGroup();
    }

    initFormGroup() {
        this.userForm = new FormGroup({
            firstName: new FormControl('', [Validators.required]),
            lastName: new FormControl('', [Validators.required]),  
            socialSkills: new FormControl(''),  
            twitterAddress: new FormControl(''),  
            linkedInAddress: new FormControl(''),  
            facebookAddress: new FormControl(''),  
        });
    }

    onSubmitClick() {
        let user = this.ngFormUser.value;
        user.socialAccounts = [];

        if(user.twitterAddress!= "")
        {
            let twitterSocialAccount = new SocialAccount();
            twitterSocialAccount.address = user.twitterAddress;
            twitterSocialAccount.type = "Twitter";
            user.socialAccounts.push(twitterSocialAccount);
        }

        if(user.facebookAddress!= "")
        {
            let facebookSocialAccount = new SocialAccount();
            facebookSocialAccount.address = user.facebookAddress;
            facebookSocialAccount.type = "Facebook";
            user.socialAccounts.push(facebookSocialAccount);
        }

        if(user.linkedInAddress!= "")
        {
            let linkedInSocialAccount = new SocialAccount();
            linkedInSocialAccount.address = user.linkedInAddress;
            linkedInSocialAccount.type = "LinkedIn";
            user.socialAccounts.push(linkedInSocialAccount);
        }

        this.addUser(this.ngFormUser.value);
    }
    addUser(user: User) {
        this.userService.analyseUserData(user).subscribe(
            userObjectResult => {
               this.userObjectResult = userObjectResult;
               this.displayDialog = false;
               this.userObjectResult.jsonString = JSON.parse(this.userObjectResult.jsonString);
            },
            error => {
                console.log(error);
                this.messageService.add({severity:'error', summary:'Error', detail:'Something went wrong'});
            }
        )
    }

    openDialog()
    {
        console.log("test");
        this.displayDialog = true;
    }

    onShow() {
    }

    onHide(){
        this.displayDialog = false;
    }
}