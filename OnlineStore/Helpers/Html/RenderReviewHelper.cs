using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using OnlineStore.Models.Domain;
using System.Text.Encodings.Web;

namespace OnlineStore.Helpers.Html
{
    public static class RenderReviewHelper
    {
        public static HtmlString RenderReviewListElement(this IHtmlHelper htmlHelper, Review review)
        {
            TagBuilder li = new TagBuilder("li");
            li.Attributes.Add("class", "list-group-item");

            TagBuilder card = CreateCard(review);

            li.InnerHtml.AppendHtml(card);

            using StringWriter sw = new StringWriter();
            li.WriteTo(sw, HtmlEncoder.Default);

            return new HtmlString(sw.ToString());
        }

        private static TagBuilder CreateCard(Review review)
        {
            TagBuilder card = new TagBuilder("div");
            card.Attributes.Add("class", "card w-100 mb-3");

            TagBuilder cardHeader = AddHeaderToCard(review);
            card.InnerHtml.AppendHtml(cardHeader);

            TagBuilder cardBody = AddBodyToCard(review);

            card.InnerHtml.AppendHtml(cardBody);

            return card;
        }

        private static TagBuilder AddHeaderToCard(Review review)
        {
            TagBuilder cardHeader = new TagBuilder("div");
            cardHeader.Attributes.Add("class", "card-header d-inline-flex justify-content-between  bg-primary text-white");

            TagBuilder author = AddAuthorToCard(review);

            TagBuilder rating = AddReitingToCard(review);

            cardHeader.InnerHtml.AppendHtml(author);
            cardHeader.InnerHtml.AppendHtml(rating);
            
            return cardHeader;
        }

        private static TagBuilder AddAuthorToCard(Review review)
        {
            TagBuilder author = new TagBuilder("div");
            author.InnerHtml.Append($"Author: {review.Author}");

            return author;
        }

        private static TagBuilder AddReitingToCard(Review review)
        {
            TagBuilder rating = new TagBuilder("div");
            rating.InnerHtml.Append($"Raiting: {review.Rating.ToString()}");

            return rating;
        }

        private static TagBuilder AddBodyToCard(Review review)
        {
            TagBuilder cardBody = new TagBuilder("div");

            cardBody.Attributes.Add("class", "card-body  bg-light");
            cardBody.InnerHtml.Append(review.Content);

            return cardBody;
        }
    }
}
