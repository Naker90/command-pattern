public class SaveCommentaryController : Controller
{
    private SaveCommentaryHandler saveCommentaryHandler;

    public SaveCommentaryController(
      SaveCommentaryHandler saveCommentaryHandler)
    {
      saveCommentaryHandler = saveCommentaryHandler;
    }

    public ActionResult Do(SaveCommentaryRequest request)
    {
      try{
        var command = SaveCommentaryCommand.Build(
          userId: request.userId,
          pictureId: request.pictureId,
          commentary: request.commentary);
        saveCommentaryHandler.Execute(command: command);
        return Json(new { status = 200, message = request.pictureId });
      }
      catch (CommentaryCanNotBeEmptyOrNullException exception)
      {
        return Json(new { status = 400, error = "El comentario no puede estar vacío." });
      }
      catch (Exception exception)
      {
        return Json(new {status = 400, error = "Excepción no controlada." });
      }
    }
}
