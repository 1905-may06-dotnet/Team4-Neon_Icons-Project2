export class AuthConfig {
    client_id: string = "208a44d2f0e34e378facf5b39ddc6568";
    response_type: string = "token";
    //redirect_uri: string = "http://localhost:4200/spotifycallback";
    redirect_uri: string = "https://neonicons.azurewebsites.net/spotifycallback";
    state: string = "";
    show_dialog: string = "false";
    scope: string = "user-read-private user-read-email streaming user-modify-playback-state"
}