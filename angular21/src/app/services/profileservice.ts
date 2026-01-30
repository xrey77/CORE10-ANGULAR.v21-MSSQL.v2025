import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Observable } from 'rxjs';
import { Profile } from '../interface/profile';

interface ActivateMfa {
  twofactorenabled: boolean;
}

@Injectable({
  providedIn: 'root'
})

export class Profileservice {
  
  private http = inject(HttpClient)
    
  public getUserbyId(id: any, token: any): Observable<any> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': `Bearer ${token}`
      })
    };    
    return this.http.get(`http://localhost:5270/api/getuserbyid/${id}`, options);
  }

  public ActivateMFA(id: any, enabled: ActivateMfa, token: any) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': `Bearer ${token}`
      })
    };    
    return this.http.patch(`http://localhost:5270/api/mfa/activate/${id}`, enabled, options);
  }

  public UploadPicture(id: any, profilepic: any, token: any): Observable<any> {
    const options = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    }; 
    return this.http.patch<any>(`http://localhost:5270/api/uploadpicture/${id}`, profilepic, options);
  }

  public sendProfileRequest(id: any,userdtls: any, token: any): Observable<any> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': `Bearer ${token}`
      })
    };    
    return this.http.patch<Profile>(`http://localhost:5270/api/updateprofile/${id}`, userdtls, options);
  }  

  public sendNewpasswordRequest(id: any, userdtls: any, token: any): Observable<any> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': `Bearer ${token}`
      })
    };    
    return this.http.patch<Profile>(`http://localhost:5270/api/changepassword/${id}`, userdtls, options);
  }  
  
}
