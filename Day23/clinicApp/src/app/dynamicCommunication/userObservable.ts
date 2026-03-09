import { BehaviorSubject, Observable } from "rxjs";

export var myObservable = new Observable<string>(o=>{
    
    o.next("Observable Started");
    o.next("Observable Emitting Data");
    
    o.complete();
});

export var changeUserStatus = new BehaviorSubject<string>("");

export var $userStatus = changeUserStatus.asObservable();

export function userLogin(username: string){
    changeUserStatus.next(username);
}

export function userLogout(){
    changeUserStatus.next("");
}