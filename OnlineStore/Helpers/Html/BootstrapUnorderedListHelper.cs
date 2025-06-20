using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Models.Domain;
using System.Text.Encodings.Web;

namespace OnlineStore.Helpers.Html
{
    public static class BootstrapUnorderedListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper htmlHelper, IEnumerable<Review> reviews)
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.Attributes.Add("class", "w-50 p-0");
            foreach (Review review in reviews)
            {
                TagBuilder li = new TagBuilder("li");
                li.Attributes.Add("class", "list-group-item");
                //Создаем карточку отзыва
                TagBuilder card = new TagBuilder("div");
                card.Attributes.Add("class", "card w-100 mb-3");
                //Создаем заголовок карточки отзыва
                TagBuilder cardHeader = new TagBuilder("div");
                cardHeader.Attributes.Add("class", "card-header d-inline-flex justify-content-between  bg-primary text-white");
                //Создаем содержимое заголовока карточки отзыва - автора и рейтинг
                TagBuilder author = new TagBuilder("div");
                author.InnerHtml.Append($"Author: {review.Author}");

                TagBuilder rating = new TagBuilder("div");
                rating.InnerHtml.Append($"Raiting: {review.Rating.ToString()}");

                cardHeader.InnerHtml.AppendHtml(author);
                cardHeader.InnerHtml.AppendHtml(rating);
                //Создаем тело карточки отзыва
                TagBuilder cardBody = new TagBuilder("div");
                cardBody.Attributes.Add("class", "card-body  bg-light");
                cardBody.InnerHtml.Append(review.Content);

                card.InnerHtml.AppendHtml(cardHeader);
                card.InnerHtml.AppendHtml(cardBody);

                li.InnerHtml.AppendHtml(card);

                ul.InnerHtml.AppendHtml(li);
            }
            using StringWriter sw = new StringWriter();
            ul.WriteTo(sw, HtmlEncoder.Default);

            return new HtmlString(sw.ToString());
        }
    }
}
