import { Component, OnInit, TemplateRef  } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { first } from "rxjs/operators";
import { UserView } from "../_models/userView";
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent implements OnInit {

  model = new Array<UserView>();
  modal = new UserView();
  modalRef: BsModalRef;

  constructor(private http: HttpClient,
    private modalService: BsModalService) { }

  ngOnInit() {
    this.loadList();
  }

  loadList() {
    this.http.get<Array<UserView>>("AdminUsers/GetTable")
      .pipe(first())
      .subscribe((data: Array<UserView>) => {
        this.model = data;
      });
  }

  openModal(template: TemplateRef<any>, p: UserView) {
    if (p == null) {
      this.modal = new UserView();
      this.modal.id = 0;
    }
    else this.modal = this.clone(p);
    this.modalRef = this.modalService.show(template);
  }

  updateUser() {
    this.http.post<Array<UserView>>("AdminUsers/UpdateUser", this.modal)
      .pipe(first())
      .subscribe((data: Array<UserView>) => {
        this.modalRef.hide();
        this.model = data;
      });
  }

  clone(model: any) {
    const d = JSON.stringify(model);
    return JSON.parse(d);
  }
}
