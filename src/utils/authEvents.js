import EventEmitter from "events";

class AuthEvents extends EventEmitter {}

const authEvents = new AuthEvents();

export default authEvents;