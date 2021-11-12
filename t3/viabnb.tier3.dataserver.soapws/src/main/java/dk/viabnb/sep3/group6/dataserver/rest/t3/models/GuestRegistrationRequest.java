package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class GuestRegistrationRequest
{
  private int id;
  private int studentNumber;
  private String studentImage;
  private RequestStatus status = RequestStatus.NotAnswered;

  public GuestRegistrationRequest(int id, int studentNumber,
      String studentImage, RequestStatus status)
  {
    this.id = id;
    this.studentNumber = studentNumber;
    this.studentImage = studentImage;
    this.status = status;
  }

  public int getId()
  {
    return id;
  }

  public void setId(int id)
  {
    this.id = id;
  }

  public int getStudentNumber()
  {
    return studentNumber;
  }

  public void setStudentNumber(int studentNumber)
  {
    this.studentNumber = studentNumber;
  }

  public String getStudentImage()
  {
    return studentImage;
  }

  public void setStudentImage(String studentImage)
  {
    this.studentImage = studentImage;
  }

  public RequestStatus getStatus()
  {
    return status;
  }

  public void setStatus(RequestStatus status)
  {
    this.status = status;
  }

}
